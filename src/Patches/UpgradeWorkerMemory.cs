using HarmonyLib;
using Modnauts;

[HarmonyPatch(typeof(UpgradeWorkerMemory))]
[HarmonyPatch("GetIsTypeUpgradeWorkerMemory")]
class UpgradeWorkerMemory_GetIsTypeUpgradeWorkerMemory
{
    static void Postfix(ref bool __result, ObjectType NewType)
    {
        try
        {
            //allow custom memory upgrades to be recognized as upgrades by the game, so they can be used in the same way as the base game ones
            if (ModManager.Instance.ModUpgradeWorkerMemoryClass.IsItCustomType(NewType))
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in UpgradeWorkerMemory_GetIsTypeUpgradeWorkerMemory patch: {ex}");
        }
    }
}


[HarmonyPatch(typeof(UpgradeWorkerMemory))]
[HarmonyPatch("PostCreate")]
class UpgradeWorkerMemory_PostCreate
{
    static void Postfix(UpgradeWorkerMemory __instance)
    {
        try
        {
            //standard upgrades has Level set in the Prefab, we override it via Variable for custom upgrades
            if (ModManager.Instance.ModUpgradeWorkerMemoryClass.IsItCustomType(__instance.m_TypeIdentifier))
            {
                __instance.m_Level = VariableManager.Instance.GetVariableAsInt(__instance.m_TypeIdentifier, "Level", false);
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in UpgradeWorkerMemory_PostCreate patch: {ex}");
        }
    }
}


