using BepInEx.Logging;
using HarmonyLib;
using Modnauts;
using MoonSharp.Interpreter;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static GameOptions;


[MoonSharpUserData]
public class ModnautWorld
{
    public Mod m_Mod = null;
    private GameOptions m_Options = null;
    private bool m_IsCustomWorld = false;
    private bool m_AllowOtherMods = true;

    public Mod GetMod()
    {
        return m_Mod;
    }
    public GameOptions GetOptions()
    {
        return m_Options;
    }
    public bool IsCustomWorld()
    {
        return m_IsCustomWorld;
    }
    public bool AllowOtherMods()
    {
        return m_AllowOtherMods;
    }

    public void DefaultWorldCreation()
    {
        m_Mod = null;
        m_Options = null;
        m_IsCustomWorld = false;
        m_AllowOtherMods = true;
    }

    public void CreateCustomWorld(string Name, int Size, bool AllowOtherMods = false)
    {
        try
        {
            m_Mod = ModManager.Instance.GetLastCalledMod();
            if (!m_Mod.IsEnabled)
            {
                return;
            }
            //SaveLoadManager.m_EmptyWorld
            //
            m_Options = new GameOptions();
            m_Options.m_MapTileData = null;
            m_Options.m_GameMode = GameMode.ModeFree;

            m_Options.m_SizeScaler[2] = 0.0f;
            m_Options.m_Sizes[2] = new Vector2Int(Plot.m_PlotTilesWide * Size, Plot.m_PlotTilesHigh * Size);
            m_Options.SetMapSize(GameSize.Large);

            if (Size % 2 == 0)
                m_Options.m_PlayerPosition = new TileCoord(m_Options.m_MapWidth / 2 + Plot.m_PlotTilesWide / 2, m_Options.m_MapHeight / 2 + Plot.m_PlotTilesHigh / 2);
            else
                m_Options.m_PlayerPosition = new TileCoord(m_Options.m_MapWidth / 2, m_Options.m_MapHeight / 2);
            //m_Options.m_PlayerPosition = m_Options.GetStartPosition(m_Options.m_GameMode);

            m_Options.m_StartPosition = m_Options.m_PlayerPosition;
            m_Options.m_RandomObjectsEnabled = false;
            m_Options.m_BadgeUnlocksEnabled = false;
            m_Options.m_TutorialEnabled = false;
            m_Options.m_RecordingEnabled = false;
            m_Options.m_BotRechargingEnabled = true;
            m_Options.m_BotLimitEnabled = true;
            m_Options.NewMapSeed();
            m_Options.m_MapName = Name;
            //var map = new Tile.TileType[m_Options.m_MapWidth * m_Options.m_MapHeight];
            //for (int j = 0; j < m_Options.m_MapHeight; j++)
            //    for (int i = 0; i < m_Options.m_MapWidth; i++)
            //    {
            //        map[j * m_Options.m_MapWidth + i] = Tile.TileType.Empty;
            //    }
            //m_Options.SetMapData(map, m_Options.m_MapWidth, m_Options.m_MapHeight, m_Options.m_StartPosition, m_Options.m_StartPosition);
            //
            m_IsCustomWorld = true;
            m_AllowOtherMods = AllowOtherMods;
        }
        catch (Exception e)
        {
            ModnautsPlugin.Logger.LogError($"CreateCustomWorld: {e.Message}");
        }
    }

    public void ClearWorld()
    {
        try
        {
            TileCoord topLeft = new TileCoord(0, 0);
            TileCoord bottomRight = new TileCoord(TileManager.Instance.m_TilesWide - 1, TileManager.Instance.m_TilesHigh - 1);
            ClearArea(topLeft, bottomRight);
            MapManager.Instance.ClearArea(topLeft, bottomRight);
        }
        catch (Exception e)
        {
            ModnautsPlugin.Logger.LogError($"ClearWorld: {e.Message}");
        }
    }

    public void SetObjectTypeEnabledAll(bool enabled)
    {
        for (int i = 0; i < (int)ObjectTypeList.m_Total; i++)
        {
            ObjectType newType = (ObjectType)i;
            ObjectTypeList.Instance.SetEnabled(newType, enabled);
        }
    }
    public void SetObjectTypeEnabled(string objectType, bool enabled)
    {
        if (Enum.TryParse(objectType, out ObjectType newType))
        {
            ObjectTypeList.Instance.SetEnabled(newType, enabled);
        }
    }

    public void SetSubCategoryForType(string objectType, string subCategory)
    {

        if (Enum.TryParse(objectType, out ObjectType newType))
        {
            if (Enum.TryParse(subCategory, out ObjectSubCategory newCategory))
            {
                ObjectTypeList.Instance.SetSubCategoryForType(newType, newCategory);
            }
        }
    }


    public void ClearArea(TileCoord TopLeft, TileCoord BottomRight, bool Nests = true)
    {
        List<TileCoordObject> list = new List<TileCoordObject>();
        for (int i = TopLeft.y; i <= BottomRight.y; i++)
        {
            for (int j = TopLeft.x; j <= BottomRight.x; j++)
            {
                TileCoord tileCoord = new TileCoord(j, i);
                Tile tile = TileManager.Instance.GetTile(tileCoord);
                if (Nests)
                {
                    List<TileCoordObject> objectsAtTile = PlotManager.Instance.GetObjectsAtTile(tileCoord);
                    if (objectsAtTile != null)
                    {
                        foreach (TileCoordObject item in objectsAtTile)
                        {
                            if (item is MyTree)
                            {
                                list.Add(item);
                            }
                        }
                        while (list.Count > 0)
                        {
                            var item2 = list[0];
                            list.Remove(item2);
                            if (item2 is MyTree)
                            {
                                var tree = (MyTree)item2;
                                if ((bool)tree.m_BeesNest)
                                {
                                    list.Add(item2);
                                    var nest = tree.DetachBeesNest();
                                    ModnautsPlugin.Logger.LogInfo($"{nest.m_TypeIdentifier} removed");
                                    nest.StopUsing();
                                }
                            }
                        }
                        list.Clear();
                    }
                }
            }
        }
    }
}

[HarmonyPatch(typeof(MainMenu))]
[HarmonyPatch("OnNewGame")]
class MainMenu_OnNewGame
{
    static bool Prefix(BaseGadget NewGadget)
    {
        try
        {
            if (ModnautsPlugin.ModnautWorldClass.IsCustomWorld())
            {
                var worldMod = ModnautsPlugin.ModnautWorldClass.GetMod();

                var haveModnauts = false;
                var haveWorldMod = false;
                var haveOtherMods = false;
                ModManager.Instance.CurrentMods.ForEach(mod =>
                {
                    if (mod.IsEnabled)
                    {
                        ModnautsPlugin.Logger.LogInfo($"MainMenu_OnNewGame: Enabled mod {mod.Name}");
                        if (mod.Name == "Modnauts")
                        {
                            haveModnauts = true;
                        }
                        else if (mod.Name == worldMod.Name)
                        {
                            haveWorldMod = true;
                        }
                        else
                        {
                            haveOtherMods = true;
                        }
                    }
                });

                if (!haveWorldMod)
                {
                    ModnautsPlugin.Logger.LogInfo($"MainMenu_OnNewGame: Defaulting because World Mod not enabled.");
                    ModnautsPlugin.ModnautWorldClass.DefaultWorldCreation();
                    return true;//world mod not enabled, run original method to create world
                }
                if (!ModnautsPlugin.ModnautWorldClass.AllowOtherMods())
                {
                    if (haveOtherMods)
                    {
                        ModnautsPlugin.Logger.LogWarning($"MainMenu_OnNewGame: Other mods are enabled along with world mod {worldMod.Name}. This may cause issues.");
                        ModnautsPlugin.ModnautDialogClass.ShowPopup($"{worldMod.Name}", $"Other mods are enabled along with custom world generation. This has been disallowed.");
                        return false;
                    }
                }

                ModnautsPlugin.Logger.LogInfo($"MainMenu_OnNewGame: Creating custom world.");

                GameOptionsManager.Instance.m_Options = ModnautsPlugin.ModnautWorldClass.GetOptions();
                GameOptionsManager.Instance.m_NewOptions = ModnautsPlugin.ModnautWorldClass.GetOptions();
                ModManager.Instance.ResetBeforeLoad();//reload active scripts
                SessionManager.Instance.LoadLevel(false, "Main");

                return false;
            }

        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in MainMenu_OnNewGame patch: {ex}");
        }

        return true; // Return false to skip the original method entirely
    }
}