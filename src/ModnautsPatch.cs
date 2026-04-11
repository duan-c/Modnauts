using HarmonyLib;
using Modnauts;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static CeremonyManager;

[HarmonyPatch(typeof(Mod))]
[HarmonyPatch("RegisterScriptGlobals")]
class Mod_RegisterScriptGlobals
{
    static bool Prefix(Script NewScript)
    {
        try
        {
            //UNDONE sourcecode not loaded at this stage.
            //for (int i = 0; i < NewScript.SourceCodeCount; i++)
            //{
            //    var code = NewScript.GetSourceCode(i);
            //    ModnautsPlugin.Logger.LogInfo($"Script: {code.Name}");
            //}

            if (NewScript?.Globals != null)
            {
                NewScript.Globals["ModnautLogger"] = ModnautsPlugin.ModnautLoggerClass;
                ModnautsPlugin.Logger.LogInfo($"ModnautLogger successfully added to script!");
                NewScript.Globals["ModnautDialog"] = ModnautsPlugin.ModnautDialogClass;
                ModnautsPlugin.Logger.LogInfo($"ModnautDialog successfully added to script!");
                NewScript.Globals["ModnautWorld"] = ModnautsPlugin.ModnautWorldClass;
                ModnautsPlugin.Logger.LogInfo($"ModnautWorld successfully added to script!");
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in Mod_RegisterScriptGlobals patch: {ex}");
        }


        return true; // Return false to skip the original method entirely
    }
}

[HarmonyPatch(typeof(TutorialPanelController))]
[HarmonyPatch("SetTutorBotActive")]
class TutorialPanelController_SetTutorBotActive
{
    static bool Prefix(bool Active)
    {
        try
        {
            if (TutorBot.Instance == null)
            {
                BaseClass baseClass = ObjectTypeList.Instance.CreateObjectFromIdentifier(ObjectType.TutorBot, default(TileCoord).ToWorldPositionTileCentered(), Quaternion.identity);
                baseClass.GetComponent<TutorBot>().UpdatePositionToTilePosition(new TileCoord(0, 0/*Plot.m_PlotTilesHigh*/));
                baseClass.gameObject.SetActive(false);
            }
            if (!Active)
            {
                if (TutorBot.Instance.gameObject.activeSelf && TutorBot.Instance.m_State != TutorBot.State.Away)
                {
                    TutorBot.Instance.SetState(TutorBot.State.Away);
                }
            }
            else if (!TutorBot.Instance.gameObject.activeSelf)
            {
                List<BaseClass> players = CollectionManager.Instance.GetPlayers();
                if (players.Count > 0)
                {
                    TileCoord randomEmptyTile = TileHelpers.GetRandomEmptyTile(players[0].GetComponent<FarmerPlayer>().m_TileCoord);
                    TutorBot.Instance.UpdatePositionToTilePosition(randomEmptyTile);
                }
                TutorBot.Instance.gameObject.SetActive(Active);
                TutorBot.Instance.SetState(TutorBot.State.Appear);
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in Mod_RegisterScriptGlobals patch: {ex}");
        }
        return false;
    }
}


////[HarmonyPatch(typeof(FailSafeManager))]
////[HarmonyPatch("Update")]
////class FailSafeManager_Update
////{
////    static bool Prefix()
////    {
////        if (ModnautsPlugin.ModnautWorldClass.DisableFailsafe())
////        {
////            return false;
////        }
        
////        return true;
////    }
////}


////[HarmonyPatch(typeof(TutorialDialog))]
////[HarmonyPatch("StartSpeech")]
////class TutorialDialog_StartSpeech
////{
////    static bool Prefix(ref string Description, ref bool Ceremony, ref string TutorVoice, ref bool UpdateTutorBot)
////    {
////        ModnautsPlugin.ModnautLoggerClass.LogMessage($"StartSpeech called with Description: {Description}, Ceremony: {Ceremony}, TutorVoice: {TutorVoice}, UpdateTutorBot: {UpdateTutorBot}");
////        //if (!GameOptionsManager.Instance.m_Options.m_TutorialEnabled)
////        //{
////        //    UpdateTutorBot = false;
////        //}

////        return true; // Return false to skip the original method entirely
////    }
////}

[HarmonyPatch(typeof(CeremonyManager))]
[HarmonyPatch("AddCeremony")]
[HarmonyPatch(new Type[] { typeof(CeremonyType) })]
class CeremonyManager_AddCeremony
{
    static bool Prefix(CeremonyType NewType)
    {
        if (ModnautsPlugin.ModnautWorldClass.IsCustomWorld())
        {
            if (NewType == CeremonyType.CommsIntro || NewType == CeremonyType.Go)
            {
                return false;
            }
        }
        return true;
    }
}
