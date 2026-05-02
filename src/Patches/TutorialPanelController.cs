//using HarmonyLib;
//using Modnauts;
//using System.Collections.Generic;
//using UnityEngine;

///// <summary>
///// bugfix for when world is a custom size and only one plot high, so the tutorbot does not spawn outside of world area
///// </summary>
//[HarmonyPatch(typeof(TutorialPanelController))]
//[HarmonyPatch("SetTutorBotActive")]
//class TutorialPanelController_SetTutorBotActive
//{
//    static bool Prefix(bool Active)
//    {
//        try
//        {
//            if (TutorBot.Instance == null)
//            {
//                BaseClass baseClass = ObjectTypeList.Instance.CreateObjectFromIdentifier(ObjectType.TutorBot, default(TileCoord).ToWorldPositionTileCentered(), Quaternion.identity);
//                baseClass.GetComponent<TutorBot>().UpdatePositionToTilePosition(new TileCoord(0, 0/*Plot.m_PlotTilesHigh*/));
//                baseClass.gameObject.SetActive(false);
//            }
//            if (!Active)
//            {
//                if (TutorBot.Instance.gameObject.activeSelf && TutorBot.Instance.m_State != TutorBot.State.Away)
//                {
//                    TutorBot.Instance.SetState(TutorBot.State.Away);
//                }
//            }
//            else if (!TutorBot.Instance.gameObject.activeSelf)
//            {
//                List<BaseClass> players = CollectionManager.Instance.GetPlayers();
//                if (players.Count > 0)
//                {
//                    TileCoord randomEmptyTile = TileHelpers.GetRandomEmptyTile(players[0].GetComponent<FarmerPlayer>().m_TileCoord);
//                    TutorBot.Instance.UpdatePositionToTilePosition(randomEmptyTile);
//                }
//                TutorBot.Instance.gameObject.SetActive(Active);
//                TutorBot.Instance.SetState(TutorBot.State.Appear);
//            }
//        }
//        catch (System.Exception ex)
//        {
//            ModnautsPlugin.Logger.LogError($"Error in TutorialPanelController_SetTutorBotActive patch: {ex}");
//        }
//        return false;
//    }
//}

