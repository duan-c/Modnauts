using DarkTonic.MasterAudio;
using HarmonyLib;
using Modnauts;
using System.Collections.Generic;
using UnityEngine;

[HarmonyPatch(typeof(AudioManager))]
[HarmonyPatch("Mod_SoundEffect")]
class AudioManager_Mod_SoundEffect
{
    static bool Prefix(AudioManager __instance, string EventName, AudioClip NewClip)
    {
        try
        {
            var ResetEvents = Traverse.Create(__instance).Field("ResetEvents").GetValue<Dictionary<string, AudioClip>>();

            if (!ResetEvents.ContainsKey(EventName))
            {
                ResetEvents.Add(EventName, NewClip);
                CreateGroupViaDynamicCreator(EventName);
                MasterAudio.ChangeVariationClip(EventName, true, "", NewClip);
            }
            else
            {
                ResetEvents[EventName] = NewClip;
                MasterAudio.ChangeVariationClip(EventName, true, "", NewClip);
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in AudioManager_Mod_SoundEffect patch: {ex}");
        }
        return false;
    }

    static void CreateGroupViaDynamicCreator(string groupName)
    {
        GameObject baseSoundGroups = GameObject.Find("BaseSoundGroups(Clone)");
        var dynamicSoundGroupCreator = baseSoundGroups.GetComponent<DynamicSoundGroupCreator>();
        GameObject template = dynamicSoundGroupCreator.transform.Find("BaseRemoved").gameObject;

        GameObject dynamicSoundGroupGameObject = Object.Instantiate(template);
        dynamicSoundGroupGameObject.name = groupName;
        var dynamicSoundGroup = dynamicSoundGroupGameObject.GetComponent<DynamicSoundGroup>();
        GameObject dynamicGroupVariationGameObject = dynamicSoundGroup.transform.Find("BaseRemoved").gameObject;
        dynamicGroupVariationGameObject.name = "Sound";
        var dynamicGroupVariation = dynamicGroupVariationGameObject.GetComponent<DynamicGroupVariation>();

        MasterAudio.CreateSoundGroup(dynamicSoundGroup, baseSoundGroups.GetInstanceID());
    }
}
