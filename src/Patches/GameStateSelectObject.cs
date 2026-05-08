using HarmonyLib;
using Modnauts;
using System.Collections.Generic;

[HarmonyPatch(typeof(GameStateSelectObject))]
[HarmonyPatch("SetSearchType")]
class GameStateSelectObject_SetSearchType
{
    static bool Prefix(GameStateEditArea __instance, List<ObjectType> SearchTypes)
    {
        try
        {
            var m_Title = Traverse.Create(__instance).Field("m_Title");//ObjectSelectBar
            var m_SearchTypes = Traverse.Create(__instance).Field("m_SearchTypes");//List<ObjectType>
            var containsCustomSign = false;
            foreach (ObjectType type in ModManager.Instance.ModSignClass.ModIDOriginals.Keys)
            {
                containsCustomSign = containsCustomSign || SearchTypes.Contains(type);
            }
            if (SearchTypes.Contains(ObjectType.Sign) || SearchTypes.Contains(ObjectType.Sign2) || SearchTypes.Contains(ObjectType.Billboard) || SearchTypes.Contains(ObjectType.Sign3) || containsCustomSign)
            {
                m_Title.Method("SetTitle", "SelectObjectSignTitle").GetValue();
            }
            else if (SearchTypes.Contains(ObjectType.StorageGeneric))
            {
                m_Title.Method("SetTitle", "SelectObjectStorageTitle").GetValue();
            }
            m_SearchTypes.SetValue(SearchTypes);
            ModelManager.Instance.SetSearchTypesHighlight(m_SearchTypes.GetValue<List<ObjectType>>(), true, false);
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in GameStateEditArea_StartSelectSign patch: {ex}");
        }
        return false;
    }
}
