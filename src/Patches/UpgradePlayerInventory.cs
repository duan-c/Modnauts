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


[HarmonyPatch(typeof(UpgradePlayerInventory))]
[HarmonyPatch("PostCreate")]
class UpgradePlayerInventory_PostCreate
{
    static void Postfix(UpgradePlayerInventory __instance)
    {
        try
        {
            //standard upgrades has Level set in the Prefab, we override it via Variable for custom upgrades
            if (ModManager.Instance.ModUpgradePlayerInventoryClass.IsItCustomType(__instance.m_TypeIdentifier))
            {
                __instance.m_Level = VariableManager.Instance.GetVariableAsInt(__instance.m_TypeIdentifier, "Level", false);
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in UpgradePlayerInventory_PostCreate patch: {ex}");
        }
    }
}


