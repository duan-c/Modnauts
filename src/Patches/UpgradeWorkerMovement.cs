using HarmonyLib;
using Modnauts;

[HarmonyPatch(typeof(UpgradeWorkerMovement))]
[HarmonyPatch("GetIsTypeUpgradeWorkerMovement")]
class UpgradeWorkerMovement_GetIsTypeUpgradeWorkerMovement
{
    static void Postfix(ref bool __result, ObjectType NewType)
    {
        try
        {
            //allow custom movement upgrades to be recognized as upgrades by the game, so they can be used in the same way as the base game ones
            if (ModManager.Instance.ModUpgradeWorkerMovementClass.IsItCustomType(NewType))
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in UpgradeWorkerMovement_GetIsTypeUpgradeWorkerMovement patch: {ex}");
        }
    }
}


[HarmonyPatch(typeof(UpgradeWorkerMovement))]
[HarmonyPatch("PostCreate")]
class UpgradeWorkerMovement_PostCreate
{
    static void Postfix(UpgradeWorkerMovement __instance)
    {
        try
        {
            //standard upgrades has Level set in the Prefab, we override it via Variable for custom upgrades
            if (ModManager.Instance.ModUpgradeWorkerMovementClass.IsItCustomType(__instance.m_TypeIdentifier))
            {
                __instance.m_Level = VariableManager.Instance.GetVariableAsInt(__instance.m_TypeIdentifier, "Level", false);
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in UpgradeWorkerMovement_PostCreate patch: {ex}");
        }
    }
}


