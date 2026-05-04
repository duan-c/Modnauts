using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using MoonSharp.Interpreter;

namespace Modnauts;

[BepInPlugin(ModnautsPluginInfo.PLUGIN_GUID, ModnautsPluginInfo.PLUGIN_NAME, ModnautsPluginInfo.PLUGIN_VERSION)]
public class ModnautsPlugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
    public static ModnautLogger ModnautLoggerClass;

    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {ModnautsPluginInfo.PLUGIN_GUID} is loaded!");

        UserData.RegisterAssembly();

        // Initialize your classes first
        ModnautLoggerClass = new ModnautLogger();

        // Apply Harmony patches
        var harmony = new Harmony(ModnautsPluginInfo.PLUGIN_GUID);
        harmony.PatchAll();

        Logger.LogInfo($"Harmony patches applied!");
    }
}