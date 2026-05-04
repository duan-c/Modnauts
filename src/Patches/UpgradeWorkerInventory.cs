using HarmonyLib;
using Modnauts;

[HarmonyPatch(typeof(UpgradeWorkerInventory))]
[HarmonyPatch("GetIsTypeUpgradeWorkerInventory")]
class UpgradeWorkerInventory_GetIsTypeUpgradeWorkerInventory
{
    static void Postfix(ref bool __result, ObjectType NewType)
    {
        try
        {
            //allow custom inventory upgrades to be recognized as upgrades by the game, so they can be used in the same way as the base game ones
            if (ModManager.Instance.ModUpgradeWorkerInventoryClass.IsItCustomType(NewType))
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in UpgradeWorkerInventory_GetIsTypeUpgradeWorkerInventory patch: {ex}");
        }
    }
}
