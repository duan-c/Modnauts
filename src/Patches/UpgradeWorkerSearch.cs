using HarmonyLib;
using Modnauts;

[HarmonyPatch(typeof(UpgradeWorkerSearch))]
[HarmonyPatch("GetIsTypeUpgradeWorkerSearch")]
class UpgradeWorkerSearch_GetIsTypeUpgradeWorkerSearch
{
    static void Postfix(ref bool __result, ObjectType NewType)
    {
        try
        {
            //allow custom search upgrades to be recognized as upgrades by the game, so they can be used in the same way as the base game ones
            if (ModManager.Instance.ModUpgradeWorkerSearchClass.IsItCustomType(NewType))
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in UpgradeWorkerSearch_GetIsTypeUpgradeWorkerSearch patch: {ex}");
        }
    }
}


[HarmonyPatch(typeof(UpgradeWorkerSearch))]
[HarmonyPatch("PostCreate")]
class UpgradeWorkerSearch_PostCreate
{
    static void Postfix(UpgradeWorkerSearch __instance)
    {
        try
        {
            //standard upgrades has Level set in the Prefab, we override it via Variable for custom upgrades
            if (ModManager.Instance.ModUpgradeWorkerSearchClass.IsItCustomType(__instance.m_TypeIdentifier))
            {
                __instance.m_Level = VariableManager.Instance.GetVariableAsInt(__instance.m_TypeIdentifier, "Level", false);
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in UpgradeWorkerSearch_PostCreate patch: {ex}");
        }
    }
}


