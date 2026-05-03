using HarmonyLib;
using Modnauts;

public static class ModManagerExtensions
{
    public static ModUpgradePlayerInventory ModUpgradePlayerInventoryClass = new ModUpgradePlayerInventory();
    public static ModUpgradePlayerMovement ModUpgradePlayerMovementClass = new ModUpgradePlayerMovement();
    public static ModUpgradePlayerWhistle ModUpgradePlayerWhistleClass = new ModUpgradePlayerWhistle();
    public static ModUpgradeWorkerInventory ModUpgradeWorkerInventoryClass = new ModUpgradeWorkerInventory();
    public static ModUpgradeWorkerCarry ModUpgradeWorkerCarryClass = new ModUpgradeWorkerCarry();
    public static ModUpgradeWorkerEnergy ModUpgradeWorkerEnergyClass = new ModUpgradeWorkerEnergy();
    public static ModUpgradeWorkerMemory ModUpgradeWorkerMemoryClass = new ModUpgradeWorkerMemory();
    public static ModUpgradeWorkerMovement ModUpgradeWorkerMovementClass = new ModUpgradeWorkerMovement();
    public static ModUpgradeWorkerSearch ModUpgradeWorkerSearchClass = new ModUpgradeWorkerSearch();
    public static ModUpgrade ModUpgradeClass = new ModUpgrade();

    extension(ModManager modManager)
    {
        //our Mod Classes will always be available just like the base game ones
        public ModUpgradePlayerInventory ModUpgradePlayerInventoryClass => ModManagerExtensions.ModUpgradePlayerInventoryClass;
        public ModUpgradePlayerMovement ModUpgradePlayerMovementClass => ModManagerExtensions.ModUpgradePlayerMovementClass;
        public ModUpgradePlayerWhistle ModUpgradePlayerWhistleClass => ModManagerExtensions.ModUpgradePlayerWhistleClass;
        public ModUpgradeWorkerInventory ModUpgradeWorkerInventoryClass => ModManagerExtensions.ModUpgradeWorkerInventoryClass;
        public ModUpgradeWorkerCarry ModUpgradeWorkerCarryClass => ModManagerExtensions.ModUpgradeWorkerCarryClass;
        public ModUpgradeWorkerEnergy ModUpgradeWorkerEnergyClass => ModManagerExtensions.ModUpgradeWorkerEnergyClass;
        public ModUpgradeWorkerMemory ModUpgradeWorkerMemoryClass => ModManagerExtensions.ModUpgradeWorkerMemoryClass;
        public ModUpgradeWorkerMovement ModUpgradeWorkerMovementClass => ModManagerExtensions.ModUpgradeWorkerMovementClass;
        public ModUpgradeWorkerSearch ModUpgradeWorkerSearchClass => ModManagerExtensions.ModUpgradeWorkerSearchClass;
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
            __instance.ModCustomClasses.Add(__instance.ModUpgradePlayerInventoryClass);
            __instance.ModUpgradePlayerInventoryClass.Init();
            __instance.ModCustomClasses.Add(__instance.ModUpgradePlayerMovementClass);
            __instance.ModUpgradePlayerMovementClass.Init();
            __instance.ModCustomClasses.Add(__instance.ModUpgradePlayerWhistleClass);
            __instance.ModUpgradePlayerWhistleClass.Init();
            __instance.ModCustomClasses.Add(__instance.ModUpgradeWorkerInventoryClass);
            __instance.ModUpgradeWorkerInventoryClass.Init();
            __instance.ModCustomClasses.Add(__instance.ModUpgradeWorkerCarryClass);
            __instance.ModUpgradeWorkerCarryClass.Init();
            __instance.ModCustomClasses.Add(__instance.ModUpgradeWorkerEnergyClass);
            __instance.ModUpgradeWorkerEnergyClass.Init();
            __instance.ModCustomClasses.Add(__instance.ModUpgradeWorkerMemoryClass);
            __instance.ModUpgradeWorkerMemoryClass.Init();
            __instance.ModCustomClasses.Add(__instance.ModUpgradeWorkerMovementClass);
            __instance.ModUpgradeWorkerMovementClass.Init();
            __instance.ModCustomClasses.Add(__instance.ModUpgradeWorkerSearchClass);
            __instance.ModUpgradeWorkerSearchClass.Init();
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in ModManager_Start patch: {ex}");
        }
    }
}