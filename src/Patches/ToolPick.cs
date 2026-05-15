using HarmonyLib;
using Modnauts;

[HarmonyPatch(typeof(ToolPick))]
[HarmonyPatch("GetIsTypePick")]
class ToolPick_GetIsTypePick
{
    static bool Prefix(ObjectType NewType, ref bool __result)
    {
        try
        {
            //custom items can now also be picks
            __result = false;
            if (MyTool.GetType(NewType) == MyTool.Type.Pick)
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in ToolPick_GetIsTypePick patch: {ex}");
        }
        return false;
    }
}
