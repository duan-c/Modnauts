using HarmonyLib;
using Modnauts;

[HarmonyPatch(typeof(UpgradeWorkerCarry))]
[HarmonyPatch("GetIsTypeUpgradeWorkerCarry")]
class UpgradeWorkerCarry_GetIsTypeUpgradeWorkerCarry
{
    static void Postfix(ref bool __result, ObjectType NewType)
    {
        try
        {
            //allow custom carry upgrades to be recognized as upgrades by the game, so they can be used in the same way as the base game ones
            if (ModManager.Instance.ModUpgradeWorkerCarryClass.IsItCustomType(NewType))
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in UpgradeWorkerCarry_GetIsTypeUpgradeWorkerCarry patch: {ex}");
        }
    }
}


[HarmonyPatch(typeof(UpgradeWorkerCarry))]
[HarmonyPatch("PostCreate")]
class UpgradeWorkerCarry_PostCreate
{
    static void Postfix(UpgradeWorkerCarry __instance)
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


