//using HarmonyLib;
//using Modnauts;
//using MoonSharp.Interpreter;
//using System;
//using System.Collections.Generic;
//using UnityEngine;
//using static GameOptions;


//[MoonSharpUserData]
//public class ModnautWorld
//{
//    public Mod m_Mod = null;
//    private GameOptions m_Options = null;
//    private bool m_IsCustomWorld = false;
//    private bool m_AllowOtherMods = true;

//    public Mod GetMod()
//    {
//        return m_Mod;
//    }
//    public GameOptions GetOptions()
//    {
//        return m_Options;
//    }
//    public bool IsCustomWorld()
//    {
//        return m_IsCustomWorld;
//    }
//    public bool AllowOtherMods()
//    {
//        return m_AllowOtherMods;
//    }

//    public void DefaultWorldCreation()
//    {
//        m_Mod = null;
//        m_Options = null;
//        m_IsCustomWorld = false;
//        m_AllowOtherMods = true;
//    }

//    public void CreateCustomWorld(string Name, int Size, bool AllowOtherMods = false)
//    {
//        try
//        {
//            m_Mod = ModManager.Instance.GetLastCalledMod();
//            if (!m_Mod.IsEnabled)
//            {
//                return;
//            }
//            //SaveLoadManager.m_EmptyWorld
//            //
//            m_Options = new GameOptions();
//            m_Options.m_MapTileData = null;
//            m_Options.m_GameMode = GameMode.ModeFree;

//            m_Options.m_SizeScaler[2] = 0.0f;
//            m_Options.m_Sizes[2] = new Vector2Int(Plot.m_PlotTilesWide * Size, Plot.m_PlotTilesHigh * Size);
//            m_Options.SetMapSize(GameSize.Large);

//            if (Size % 2 == 0)
//                m_Options.m_PlayerPosition = new TileCoord(m_Options.m_MapWidth / 2 + Plot.m_PlotTilesWide / 2, m_Options.m_MapHeight / 2 + Plot.m_PlotTilesHigh / 2);
//            else
//                m_Options.m_PlayerPosition = new TileCoord(m_Options.m_MapWidth / 2, m_Options.m_MapHeight / 2);
//            //m_Options.m_PlayerPosition = m_Options.GetStartPosition(m_Options.m_GameMode);

//            m_Options.m_StartPosition = m_Options.m_PlayerPosition;
//            m_Options.m_RandomObjectsEnabled = false;
//            m_Options.m_BadgeUnlocksEnabled = false;
//            m_Options.m_TutorialEnabled = false;
//            m_Options.m_RecordingEnabled = false;
//            m_Options.m_BotRechargingEnabled = true;
//            m_Options.m_BotLimitEnabled = true;
//            m_Options.NewMapSeed();
//            m_Options.m_MapName = Name;
//            //var map = new Tile.TileType[m_Options.m_MapWidth * m_Options.m_MapHeight];
//            //for (int j = 0; j < m_Options.m_MapHeight; j++)
//            //    for (int i = 0; i < m_Options.m_MapWidth; i++)
//            //    {
//            //        map[j * m_Options.m_MapWidth + i] = Tile.TileType.Empty;
//            //    }
//            //m_Options.SetMapData(map, m_Options.m_MapWidth, m_Options.m_MapHeight, m_Options.m_StartPosition, m_Options.m_StartPosition);
//            //
//            m_IsCustomWorld = true;
//            m_AllowOtherMods = AllowOtherMods;
//        }
//        catch (Exception e)
//        {
//            ModnautsPlugin.Logger.LogError($"CreateCustomWorld: {e.Message}");
//        }
//    }

//    public void ClearWorld()
//    {
//        try
//        {
//            TileCoord topLeft = new TileCoord(0, 0);
//            TileCoord bottomRight = new TileCoord(TileManager.Instance.m_TilesWide - 1, TileManager.Instance.m_TilesHigh - 1);
//            ClearArea(topLeft, bottomRight);
//            MapManager.Instance.ClearArea(topLeft, bottomRight);
//        }
//        catch (Exception e)
//        {
//            ModnautsPlugin.Logger.LogError($"ClearWorld: {e.Message}");
//        }
//    }

//    public void SetObjectTypeEnabledAll(bool enabled)
//    {
//        for (int i = 0; i < (int)ObjectTypeList.m_Total; i++)
//        {
//            ObjectType newType = (ObjectType)i;
//            ObjectTypeList.Instance.SetEnabled(newType, enabled);
//        }
//    }
//    public void SetObjectTypeEnabled(string objectType, bool enabled)
//    {
//        if (Enum.TryParse(objectType, out ObjectType newType))
//        {
//            ObjectTypeList.Instance.SetEnabled(newType, enabled);
//        }
//    }

//    public void SetSubCategoryForType(string objectType, string subCategory)
//    {

//        if (Enum.TryParse(objectType, out ObjectType newType))
//        {
//            if (Enum.TryParse(subCategory, out ObjectSubCategory newCategory))
//            {
//                ObjectTypeList.Instance.SetSubCategoryForType(newType, newCategory);
//            }
//        }
//    }


//    public void ClearArea(TileCoord TopLeft, TileCoord BottomRight, bool Nests = true)
//    {
//        List<TileCoordObject> list = new List<TileCoordObject>();
//        for (int i = TopLeft.y; i <= BottomRight.y; i++)
//        {
//            for (int j = TopLeft.x; j <= BottomRight.x; j++)
//            {
//                TileCoord tileCoord = new TileCoord(j, i);
//                Tile tile = TileManager.Instance.GetTile(tileCoord);
//                if (Nests)
//                {
//                    List<TileCoordObject> objectsAtTile = PlotManager.Instance.GetObjectsAtTile(tileCoord);
//                    if (objectsAtTile != null)
//                    {
//                        foreach (TileCoordObject item in objectsAtTile)
//                        {
//                            if (item is MyTree)
//                            {
//                                list.Add(item);
//                            }
//                        }
//                        while (list.Count > 0)
//                        {
//                            var item2 = list[0];
//                            list.Remove(item2);
//                            if (item2 is MyTree)
//                            {
//                                var tree = (MyTree)item2;
//                                if ((bool)tree.m_BeesNest)
//                                {
//                                    list.Add(item2);
//                                    var nest = tree.DetachBeesNest();
//                                    ModnautsPlugin.Logger.LogInfo($"{nest.m_TypeIdentifier} removed");
//                                    nest.StopUsing();
//                                }
//                            }
//                        }
//                        list.Clear();
//                    }
//                }
//            }
//        }
//    }
//}
