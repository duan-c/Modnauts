using HarmonyLib;
using MoonSharp.Interpreter;
using Modnauts;
using System.Drawing;
using System.Drawing.Drawing2D;

[HarmonyPatch(typeof(UpgradeWorkerEnergy))]
[HarmonyPatch("GetIsTypeUpgradeWorkerEnergy")]
class UpgradeWorkerEnergy_GetIsTypeUpgradeWorkerEnergy
{
    static void Postfix(ref bool __result, ObjectType NewType)
    {
        try
        {
            //allow custom energy upgrades to be recognized as energy upgrades by the game, so they can be used in the same way as the base game ones
            if (ModManager.Instance.ModUpgradeWorkerEnergyClass.IsItCustomType(NewType))
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in UpgradeWorkerEnergy_GetIsTypeUpgradeWorkerEnergy patch: {ex}");
        }
    }
}


[HarmonyPatch(typeof(UpgradeWorkerEnergy))]
[HarmonyPatch("PostCreate")]
class UpgradeWorkerEnergy_PostCreate
{
    static void Postfix(UpgradeWorkerEnergy __instance)
    {
        try
        {
            //standard upgrades has Level set in the Prefab, we override it via Variable for custom upgrades
            if (ModManager.Instance.ModUpgradeWorkerCarryClass.IsItCustomType(__instance.m_TypeIdentifier))
            {
                __instance.m_Level = VariableManager.Instance.GetVariableAsInt(__instance.m_TypeIdentifier, "Level", false);
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in UpgradeWorkerCarry_PostCreate patch: {ex}");
        }
    }
}


