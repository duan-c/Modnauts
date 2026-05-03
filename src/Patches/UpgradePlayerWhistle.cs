using HarmonyLib;
using MoonSharp.Interpreter;
using Modnauts;
using System.Drawing;
using System.Drawing.Drawing2D;

[HarmonyPatch(typeof(UpgradePlayerWhistle))]
[HarmonyPatch("GetIsTypeUpgradePlayerWhistle")]
class UpgradePlayerWhistle_GetIsTypeUpgradePlayerWhistle
{
    static void Postfix(ref bool __result, ObjectType NewType)
    {
        try
        {
            //allow custom carry upgrades to be recognized as carry upgrades by the game, so they can be used in the same way as the base game ones
            if (ModManager.Instance.ModUpgradePlayerWhistleClass.IsItCustomType(NewType))
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in UpgradePlayerWhistle_GetIsTypeUpgradePlayerWhistle patch: {ex}");
        }
    }
}


[HarmonyPatch(typeof(UpgradePlayerWhistle))]
[HarmonyPatch("PostCreate")]
class UpgradePlayerWhistle_PostCreate
{
    static void Postfix(UpgradePlayerWhistle __instance)
    {
        try
        {
            //standard upgrades has Level set in the Prefab, we override it via Variable for custom upgrades
            if (ModManager.Instance.ModUpgradePlayerWhistleClass.IsItCustomType(__instance.m_TypeIdentifier))
            {
                __instance.m_Level = VariableManager.Instance.GetVariableAsInt(__instance.m_TypeIdentifier, "Level", false);
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in UpgradePlayerWhistle_PostCreate patch: {ex}");
        }
    }
}


