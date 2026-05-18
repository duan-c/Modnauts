using HarmonyLib;
using Modnauts;
using System;
using System.Runtime.CompilerServices;

[HarmonyPatch]
class Fish_GetActionFromObject
{
    [HarmonyPatch(typeof(Fish))]
    [HarmonyPatch("GetActionFromObject")]
    static bool Prefix(Fish __instance, AFO Info, ref ActionType __result)
    {
        try
        {
            ObjectType objectType = Info.m_ObjectType;
            if (Info.m_ActionType == AFO.AT.Primary && (objectType == ObjectType.RockSharp || ToolBlade.GetIsTypeBlade(objectType)))
            {
                __result = Traverse.Create(__instance).Method("GetActionFromSharpRock", Info).GetValue<ActionType>();
                return false;
            }
            __result = Holdable_GetActionFromObject_Stub(__instance, Info);
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in Fish_GetActionFromObject patch: {ex}");
        }
        return false;
    }

    [HarmonyReversePatch]
    [HarmonyPatch(typeof(Holdable))]
    [HarmonyPatch("GetActionFromObject")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ActionType Holdable_GetActionFromObject_Stub(Fish instance, AFO Info) => throw new NotImplementedException("Stub");
}
