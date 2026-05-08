using HarmonyLib;
using Modnauts;
using System.Collections.Generic;

[HarmonyPatch(typeof(GameStateEditArea))]
[HarmonyPatch("StartSelectSign")]
class GameStateEditArea_StartSelectSign
{
    static bool Prefix(GameStateEditArea __instance, bool Start)
    {
        try
        {
            MaterialManager.Instance.SetDesaturation(Start, Start);
            PlotManager.Instance.SetDesaturation(Start);
            List<ObjectType> list = new List<ObjectType>();
            foreach (ObjectType type in Converter.m_Types)
            {
                if (type != ObjectType.ConverterFoundation)
                {
                    list.Add(type);
                }
            }
            list.Add(ObjectType.Sign);
            list.Add(ObjectType.Sign2);
            list.Add(ObjectType.Sign3);
            list.Add(ObjectType.Billboard);
            foreach(ObjectType type in ModManager.Instance.ModSignClass.ModIDOriginals.Keys)
            {
                list.Add(type);
            }
            ModelManager.Instance.SetSearchTypesHighlight(list, Start, false);
            Traverse.Create(__instance).Method("MakeHeldSignsSelectable", Start).GetValue();
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in GameStateEditArea_StartSelectSign patch: {ex}");
        }
        return false;
    }
}
