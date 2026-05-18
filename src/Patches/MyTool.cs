using HarmonyLib;
using Modnauts;

[HarmonyPatch(typeof(MyTool))]
[HarmonyPatch("GetType")]
class MyTool_GetType
{
    static bool Prefix(ObjectType NewType, ref MyTool.Type __result)
    {
        try
        {
            if (ModManager.Instance.ModToolClass.IsItCustomType(NewType))
            {
                //bugfix: Dictionary.TryGetValue updates the out value to zero even if value is not found
                MyTool.Type value = MyTool.Type.Total;
                if (ModManager.Instance.ModToolClass.ToolBaseType.TryGetValue(NewType, out value))
                {
                    __result = value;
                }
                else
                {
                    __result = MyTool.Type.Total;
                }
                return false;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in MyTool_GetType patch: {ex}");
        }
        return true;
    }
}
