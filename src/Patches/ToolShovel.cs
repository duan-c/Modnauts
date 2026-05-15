using HarmonyLib;
using Modnauts;

[HarmonyPatch(typeof(ToolShovel))]
[HarmonyPatch("GetIsTypeShovel")]
class ToolShovel_GetIsTypeShovel
{
    static bool Prefix(ObjectType NewType, ref bool __result)
    {
        try
        {
            //custom items can now also be shovels
            __result = false;
            if (MyTool.GetType(NewType) == MyTool.Type.Shovel)
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in ToolShovel_GetIsTypeShovel patch: {ex}");
        }
        return false;
    }
}
