using HarmonyLib;
using Modnauts;
using System.Collections.Generic;
using UnityEngine;

[HarmonyPatch(typeof(MainMenu))]
[HarmonyPatch("Start")]
class MainMenu_Start
{
    static void Postfix(MainMenu __instance)
    {
        try
        {
            //display Modnauts version
            GameObject version = __instance.transform.Find("Version").gameObject;
            GameObject modnauts = Object.Instantiate(version);
            modnauts.name = ModnautsPluginInfo.PLUGIN_NAME;
            modnauts.transform.SetParent(version.transform.parent);
            modnauts.transform.position = version.transform.position;
            BaseText baseText = modnauts.GetComponent<BaseText>();
            baseText.SetText(ModnautsPluginInfo.PLUGIN_NAME + " v" + ModnautsPluginInfo.PLUGIN_VERSION);
            baseText.SetHeight(140);
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in MainMenu_Start patch: {ex}");
        }
    }
}










//using HarmonyLib;
//using Modnauts;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


///// <summary>
///// Start a new custom world instead going to the default world creation screen.
///// </summary>
//[HarmonyPatch(typeof(MainMenu))]
//[HarmonyPatch("OnNewGame")]
//class MainMenu_OnNewGame
//{
//    static bool Prefix(BaseGadget NewGadget)
//    {
//        try
//        {
//            if (ModnautsPlugin.ModnautWorldClass.IsCustomWorld())
//            {
//                var worldMod = ModnautsPlugin.ModnautWorldClass.GetMod();

//                var haveModnauts = false;
//                var haveWorldMod = false;
//                var haveOtherMods = false;
//                ModManager.Instance.CurrentMods.ForEach(mod =>
//                {
//                    if (mod.IsEnabled)
//                    {
//                        ModnautsPlugin.Logger.LogInfo($"MainMenu_OnNewGame: Enabled mod {mod.Name}");
//                        if (mod.Name == "Modnauts")
//                        {
//                            haveModnauts = true;
//                        }
//                        else if (mod.Name == worldMod.Name)
//                        {
//                            haveWorldMod = true;
//                        }
//                        else
//                        {
//                            haveOtherMods = true;
//                        }
//                    }
//                });

//                if (!haveWorldMod)
//                {
//                    ModnautsPlugin.Logger.LogInfo($"MainMenu_OnNewGame: Defaulting because World Mod not enabled.");
//                    ModnautsPlugin.ModnautWorldClass.DefaultWorldCreation();
//                    return true;//world mod not enabled, run original method to create world
//                }
//                if (!ModnautsPlugin.ModnautWorldClass.AllowOtherMods())
//                {
//                    if (haveOtherMods)
//                    {
//                        ModnautsPlugin.Logger.LogWarning($"MainMenu_OnNewGame: Other mods are enabled along with world mod {worldMod.Name}. This may cause issues.");
//                        ModManager.Instance.ModUIClass.ShowPopup($"{worldMod.Name}", $"Other mods are enabled along with custom world generation. This has been disallowed.");
//                        return false;
//                    }
//                }

//                ModnautsPlugin.Logger.LogInfo($"MainMenu_OnNewGame: Creating custom world.");

//                GameOptionsManager.Instance.m_Options = ModnautsPlugin.ModnautWorldClass.GetOptions();
//                GameOptionsManager.Instance.m_NewOptions = ModnautsPlugin.ModnautWorldClass.GetOptions();
//                ModManager.Instance.ResetBeforeLoad();//reload active scripts
//                SessionManager.Instance.LoadLevel(false, "Main");

//                return false;
//            }

//        }
//        catch (System.Exception ex)
//        {
//            ModnautsPlugin.Logger.LogError($"Error in MainMenu_OnNewGame patch: {ex}");
//        }

//        return true; // Return false to skip the original method entirely
//    }
//}
