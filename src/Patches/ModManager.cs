using HarmonyLib;
using Modnauts;

public static class ModManagerExtensions
{
    public static ModUpgradeWorkerMemory ModUpgradeWorkerMemoryClass = new ModUpgradeWorkerMemory();
    public static ModUpgrade ModUpgradeClass = new ModUpgrade();

    extension(ModManager modManager)
    {
        //our Mod Classes will always be available just like the base game ones
        public ModUpgradeWorkerMemory ModUpgradeWorkerMemoryClass => ModManagerExtensions.ModUpgradeWorkerMemoryClass;
        public ModUpgrade ModUpgradeClass => ModManagerExtensions.ModUpgradeClass;
    }
}


[HarmonyPatch(typeof(ModManager))]
[HarmonyPatch("Start")]
class ModManager_Start
{
    //Beware, patching the WakeUp method breaks MoonSharpUserData.  That is why we are using the Start method instead.  Note it could be because of exhaustion as well.
    static void Postfix(ModManager __instance)
    {
        try
        {
            //allow our custom Mods to be used in Lua scripts by adding it to the ModManager and initializing it
            __instance.ModCustomClasses.Add(__instance.ModUpgradeWorkerMemoryClass);
            __instance.ModUpgradeWorkerMemoryClass.Init();
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in ModManager_Start patch: {ex}");
        }
    }
}