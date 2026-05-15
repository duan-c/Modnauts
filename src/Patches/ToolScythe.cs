using HarmonyLib;
using Modnauts;

[HarmonyPatch(typeof(ToolScythe))]
[HarmonyPatch("GetIsTypeScythe")]
class ToolScythe_GetIsTypeScythe
{
    static bool Prefix(ObjectType NewType, ref bool __result)
    {
        try
        {
            //custom items can now also be scythes
            __result = false;
            if (MyTool.GetType(NewType) == MyTool.Type.Scythe)
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in ToolScythe_GetIsTypeScythe patch: {ex}");
        }
        return false;
    }
}
