using HarmonyLib;
using Modnauts;

[HarmonyPatch(typeof(ToolHoe))]
[HarmonyPatch("GetIsTypeHoe")]
class ToolHoe_GetIsTypeHoe
{
    static bool Prefix(ObjectType NewType, ref bool __result)
    {
        try
        {
            //custom items can now also be hoes
            __result = false;
            if (MyTool.GetType(NewType) == MyTool.Type.Hoe)
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in ToolHoe_GetIsTypeHoe patch: {ex}");
        }
        return false;
    }
}
