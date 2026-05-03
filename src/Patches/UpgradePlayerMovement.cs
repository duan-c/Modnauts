using HarmonyLib;
using MoonSharp.Interpreter;
using Modnauts;
using System.Drawing;
using System.Drawing.Drawing2D;

[HarmonyPatch(typeof(UpgradePlayerMovement))]
[HarmonyPatch("GetIsTypeUpgradePlayerMovement")]
class UpgradePlayerMovement_GetIsTypeUpgradePlayerMovement
{
    static void Postfix(ref bool __result, ObjectType NewType)
    {
        try
        {
            //allow custom carry upgrades to be recognized as carry upgrades by the game, so they can be used in the same way as the base game ones
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

