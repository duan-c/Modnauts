using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using MoonSharp.Interpreter;
using UnityEngine;

namespace Modnauts;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class ModnautsPlugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
    public static ModnautLogger ModnautLoggerClass;
    //public static ModnautWorld ModnautWorldClass;

    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        UserData.RegisterAssembly();

        // Initialize your classes first
        ModnautLoggerClass = new ModnautLogger();
        //ModnautWorldClass = new ModnautWorld();

        // Apply Harmony patches
        var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        harmony.PatchAll();

        Logger.LogInfo($"Harmony patches applied!");




    }
}