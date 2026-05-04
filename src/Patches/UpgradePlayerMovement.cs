using HarmonyLib;
using Modnauts;

[HarmonyPatch(typeof(UpgradePlayerMovement))]
[HarmonyPatch("GetIsTypeUpgradePlayerMovement")]
class UpgradePlayerMovement_GetIsTypeUpgradePlayerMovement
{
    static void Postfix(ref bool __result, ObjectType NewType)
    {
        try
        {
            //allow custom movement upgrades to be recognized as upgrades by the game, so they can be used in the same way as the base game ones
            if (ModManager.Instance.ModUpgradePlayerMovementClass.IsItCustomType(NewType))
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in UpgradePlayerMovement_GetIsTypeUpgradePlayerMovement patch: {ex}");
        }
    }
}

