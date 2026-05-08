using HarmonyLib;
using Modnauts;

[HarmonyPatch(typeof(Sign))]
[HarmonyPatch("GetIsTypeSign")]
class Sign_GetIsTypeSign
{
    static void Postfix(ref bool __result, ObjectType NewType)
    {
        try
        {
            //allow custom sign to be recognized as sign by the game, so they can be used in the same way as the base game ones
            if (ModManager.Instance.ModSignClass.IsItCustomType(NewType))
            {
                __result = true;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in Sign_GetIsTypeSign patch: {ex}");
        }
    }
}
