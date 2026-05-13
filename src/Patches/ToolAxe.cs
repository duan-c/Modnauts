using HarmonyLib;
using Modnauts;

[HarmonyPatch(typeof(ToolAxe))]
[HarmonyPatch("GetIsTypeAxe")]
class ToolAxe_GetIsTypeAxe
{
    static bool Prefix(ObjectType NewType, ref bool __result)
    {
        try
        {
            //custom items can now also be axes
            __result = false;
            if (MyTool.GetType(NewType) == MyTool.Type.Axe)
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in ToolAxe_GetIsTypeAxe patch: {ex}");
        }
        return false;
    }
}
