using HarmonyLib;
using MoonSharp.Interpreter;
using Modnauts;
using System.Drawing;
using System.Drawing.Drawing2D;

[HarmonyPatch(typeof(UpgradePlayerInventory))]
[HarmonyPatch("GetIsTypeUpgradePlayerInventory")]
class UpgradePlayerInventory_GetIsTypeUpgradePlayerInventory
{
    static void Postfix(ref bool __result, ObjectType NewType)
    {
        try
        {
            //allow custom carry upgrades to be recognized as carry upgrades by the game, so they can be used in the same way as the base game ones
            if (ModManager.Instance.ModUpgradePlayerInventoryClass.IsItCustomType(NewType))
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in UpgradePlayerInventory_GetIsTypeUpgradePlayerInventory patch: {ex}");
        }
    }
}
