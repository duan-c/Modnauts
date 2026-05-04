using HarmonyLib;
using Modnauts;
using MoonSharp.Interpreter;

[HarmonyPatch(typeof(Mod))]
[HarmonyPatch("RegisterScriptGlobals")]
class Mod_RegisterScriptGlobals
{
    static void Postfix(Script NewScript)
    {
        try
        {
            //attach our custom classes to the script globals so that they can be accessed in LUA mod Creation() etc.
            if (NewScript?.Globals != null)
            {
                NewScript.Globals["ModUpgrade"] = ModManager.Instance.ModUpgradeClass;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in Mod_RegisterScriptGlobals patch: {ex}");
        }
    }
}