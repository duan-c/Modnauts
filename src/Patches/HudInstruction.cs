using HarmonyLib;
using Modnauts;
using System.Collections.Generic;

[HarmonyPatch(typeof(HudInstruction))]
[HarmonyPatch("ObjectSelectPressed")]
class HudInstruction_ObjectSelectPressed
{
    static bool Prefix(HudInstruction __instance)
    {
        try
        {
            var m_Instruction = Traverse.Create(__instance).Field("m_Instruction").GetValue<HighInstruction>();
            if (m_Instruction.GetIsGetNearest())
            {
                GameStateManager.Instance.PushState(GameStateManager.State.SelectObject);
                List<ObjectType> list = new List<ObjectType>();
                foreach (ObjectType type in ModManager.Instance.ModSignClass.ModIDOriginals.Keys)
                {
                    list.Add(type);
                }
                GameStateManager.Instance.GetCurrentState().GetComponent<GameStateSelectObject>().SetSearchType(list);
                GameStateManager.Instance.GetCurrentState().GetComponent<GameStateSelectObject>().SetInstruction(__instance);
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in GameStateEditArea_StartSelectSign patch: {ex}");
        }
        return true;
    }
}
