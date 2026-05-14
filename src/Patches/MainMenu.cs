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