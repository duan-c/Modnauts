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


        //GameObject upgradeMod = AssetManager.LoadPrefab("WorldObjects/Special/HoldableMod");
        //upgradeMod.name = "UpgradeMod";
        //DontDestroyOnLoad(upgradeMod);
        //var upgradePlayerInventory = upgradeMod.AddComponent<UpgradePlayerInventory>();
        //var upgradePlayerMovement = upgradeMod.AddComponent<UpgradePlayerMovement>();
        //var upgradePlayerWhistle = upgradeMod.AddComponent<UpgradePlayerWhistle>();
        ////
        //var upgradeWorkerCarry = upgradeMod.AddComponent<UpgradeWorkerCarry>();
        //var upgradeWorkerEnergy = upgradeMod.AddComponent<UpgradeWorkerEnergy>();
        //var upgradeWorkerInventory = upgradeMod.AddComponent<UpgradeWorkerInventory>();
        //var upgradeWorkerMemory = upgradeMod.AddComponent<UpgradeWorkerMemory>();
        //var upgradeWorkerMovement = upgradeMod.AddComponent<UpgradeWorkerMovement>();
        //var upgradeWorkerSearch = upgradeMod.AddComponent<UpgradeWorkerSearch>();

        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerInventoryCrude, "Capacity", 1);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerInventoryGood, "Capacity", 3);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerInventorySuper, "Capacity", 5);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerMovementCrude, "Delay", 0.05f);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerMovementGood, "Delay", 0.075f);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerMovementSuper, "Delay", 0.1f);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerInventoryCrude, "Capacity", 1);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerInventoryGood, "Capacity", 2);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerInventorySuper, "Capacity", 4);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerCarryCrude, "Capacity", 1);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerCarryGood, "Capacity", 2);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerCarrySuper, "Capacity", 4);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerEnergyCrude, "DriveEnergy", 0.2f);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerEnergyGood, "DriveEnergy", 0.4f);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerEnergySuper, "DriveEnergy", 0.6f);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerMemoryCrude, "Size", 4);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerMemoryGood, "Size", 8);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerMemorySuper, "Size", 32);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerMovementCrude, "InitialDelay", 20);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerMovementCrude, "MoveScale", 0.1f);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerMovementGood, "InitialDelay", 40);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerMovementGood, "MoveScale", 0.2f);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerMovementSuper, "InitialDelay", 60);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerMovementSuper, "MoveScale", 0.3f);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerSearchCrude, "InitialDelay", 10);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerSearchCrude, "Range", 5);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerSearchGood, "InitialDelay", 20);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerSearchGood, "Range", 10);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerSearchSuper, "InitialDelay", 30);
        //VariableManager.Instance.SetVariable(ObjectType.UpgradeWorkerSearchSuper, "Range", 15);


        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerWhistleCrude, "CallSound", "WhistleBlown2");
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerWhistleCrude, "CancelSound", "WhistleCancel2");
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerWhistleCrude, "DropAllSound", "WhistleDropAll2");
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerWhistleCrude, "ToMeSound", "WhistleToMe2");
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerWhistleGood, "CallSound", "WhistleBlown3");
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerWhistleGood, "CancelSound", "WhistleCancel3");
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerWhistleGood, "DropAllSound", "WhistleDropAll3");
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerWhistleGood, "ToMeSound", "WhistleToMe3");
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerWhistleSuper, "CallSound", "WhistleBlown4");
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerWhistleSuper, "CancelSound", "WhistleCancel4");
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerWhistleSuper, "DropAllSound", "WhistleDropAll4");
        //VariableManager.Instance.SetVariable(ObjectType.UpgradePlayerWhistleSuper, "ToMeSound", "WhistleToMe4");

        //public enum Target
        //{
        //    Both,
        //    Player,
        //    Bot,
        //    Total
        //}

        //public enum Type
        //{
        //    PlayerInventory,
        //    PlayerWhistle,
        //    PlayerMovement,
        //    WorkerCarry,
        //    WorkerEnergy,
        //    WorkerInventory,
        //    WorkerMemory,
        //    WorkerMovement,
        //    WorkerSearch,
        //    Sign,
        //    Total
        //}


    }
}