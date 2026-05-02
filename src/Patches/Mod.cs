using HarmonyLib;
using Modnauts;
using MoonSharp.Interpreter;

[HarmonyPatch(typeof(Mod))]
[HarmonyPatch("RegisterScriptGlobals")]
class Mod_RegisterScriptGlobals
{
    static bool Prefix(Script NewScript)
    {
        try
        {
            if (NewScript?.Globals != null)
            {
                NewScript.Globals["ModnautLogger"] = ModnautsPlugin.ModnautLoggerClass;
                //NewScript.Globals["ModnautWorld"] = ModnautsPlugin.ModnautWorldClass;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in Mod_RegisterScriptGlobals patch: {ex}");
        }
        return true;
    }
}