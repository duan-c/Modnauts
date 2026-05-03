using HarmonyLib;
using MoonSharp.Interpreter;
using Modnauts;
using System.Drawing;
using System.Drawing.Drawing2D;

[HarmonyPatch(typeof(FarmerUpgrades))]
[HarmonyPatch("GetContainsUpgradePlayerMovement")]
class FarmerUpgrades_GetContainsUpgradePlayerMovement
{
    static void Postfix(FarmerUpgrades __instance, ref bool __result)
    {
        try
        {
            //allow custom carry upgrades to be recognized as carry upgrades by the game, so they can be used in the same way as the base game ones
            var movementUpgrade = __instance.GetMovementUpgrade();
            if (ModManager.Instance.ModUpgradePlayerMovementClass.IsItCustomType(movementUpgrade))
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in FarmerUpgrades_GetContainsUpgradePlayerMovement patch: {ex}");
        }
    }
}
