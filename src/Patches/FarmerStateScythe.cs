using HarmonyLib;
using Modnauts;

[HarmonyPatch(typeof(FarmerStateScythe))]
[HarmonyPatch("GetIsToolAcceptable")]
class FarmerStateScythe_GetIsToolAcceptable
{
    static bool Prefix(ObjectType NewType, ref bool __result)
    {
        try
        {
            if (!ToolScythe.GetIsTypeScythe(NewType))
            {
                __result = ToolBlade.GetIsTypeBlade(NewType);
                return false;
            }
            __result = true;
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in FarmerStateScythe_GetIsToolAcceptable patch: {ex}");
        }
        return false;
    }
}
