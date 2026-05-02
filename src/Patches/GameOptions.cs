
//using HarmonyLib;
//using SimpleJSON;
//using System;
//using UnityEngine;
//using static GameOptions;

///// <summary>
///// Saves the GameOptions.m_Sizes, needed for custom world sizes.
///// </summary>
//[HarmonyPatch(typeof(GameOptions))]
//[HarmonyPatch("Save")]
//class GameOptions_Save
//{//TODO maybe just do a Postfix.
//    static bool Prefix(GameOptions __instance, JSONNode Node)
//    {
//        JSONUtils.Set(Node, "GameModeName", __instance.m_GameMode.ToString());
//        JSONUtils.Set(Node, "GameSize", (int)__instance.m_GameSize);
//        JSONUtils.Set(Node, "RandomObjectsEnabled", __instance.m_RandomObjectsEnabled);
//        JSONUtils.Set(Node, "BadgeUnlocksEnabled", __instance.m_BadgeUnlocksEnabled);
//        JSONUtils.Set(Node, "RecordingEnabled", __instance.m_RecordingEnabled);
//        JSONUtils.Set(Node, "TutorialEnabled", __instance.m_TutorialEnabled);
//        JSONUtils.Set(Node, "BotRechargingEnabled", __instance.m_BotRechargingEnabled);
//        JSONUtils.Set(Node, "BotLimitEnabled", __instance.m_BotLimitEnabled);
//        JSONUtils.Set(Node, "Seed", __instance.m_MapSeed);
//        JSONUtils.Set(Node, "Name", __instance.m_MapName);
//        __instance.m_StartPosition.Save(Node, "StartPosition");
//        //m_Sizes
//        JSONArray jSONArray = (JSONArray)(Node["Sizes"] = new JSONArray());
//        int num = 0;
//        //TODO maybe create Save extension method for Vector2Int and Vector2Int array?
//        foreach (Vector2Int size in __instance.m_Sizes)
//        {
//            jSONArray[num] = size.x;
//            num++;
//            jSONArray[num] = size.y;
//            num++;
//        }

//        return false;
//    }
//}

///// <summary>
///// Loads GameOptions.m_Sizes, needed for custom world sizes.
///// </summary>
//[HarmonyPatch(typeof(GameOptions))]
//[HarmonyPatch("Load")]
//class GameOptions_Load
//{//TODO maybe just do a Postfix.
//    static bool Prefix(GameOptions __instance, JSONNode Node)
//    {
//        JSONNode jSONNode = Node["GameMode"];
//        if (jSONNode != null && !jSONNode.IsNull)
//        {
//            switch (JSONUtils.GetAsInt(Node, "GameMode", 0))
//            {
//                case 0:
//                    __instance.m_GameMode = GameMode.ModeCampaign;
//                    break;
//                case 1:
//                    __instance.m_GameMode = GameMode.ModeFree;
//                    break;
//                case 2:
//                    __instance.m_GameMode = GameMode.ModeCreative;
//                    break;
//                default:
//                    __instance.m_GameMode = GameMode.ModeCampaign;
//                    break;
//            }
//        }
//        else if (!Enum.TryParse<GameMode>(JSONUtils.GetAsString(Node, "GameModeName", GameMode.Total.ToString()), out __instance.m_GameMode))
//        {
//            __instance.m_GameMode = GameMode.Total;
//        }
//        __instance.m_GameSize = (GameSize)JSONUtils.GetAsInt(Node, "GameSize", 1);
//        if (__instance.m_GameSize == GameSize.Total)
//        {
//            __instance.m_GameSize = GameSize.Small;
//        }
//        __instance.SetMapSize(__instance.m_GameSize);
//        __instance.m_RandomObjectsEnabled = JSONUtils.GetAsBool(Node, "RandomObjectsEnabled", true);
//        __instance.m_BadgeUnlocksEnabled = JSONUtils.GetAsBool(Node, "BadgeUnlocksEnabled", true);
//        __instance.m_RecordingEnabled = false;
//        __instance.m_TutorialEnabled = JSONUtils.GetAsBool(Node, "TutorialEnabled", true);
//        if (Node["BotEnergyEnabled"] == null || Node["BotEnergyEnabled"].IsNull)
//        {
//            __instance.m_BotRechargingEnabled = JSONUtils.GetAsBool(Node, "BotRechargingEnabled", true);
//        }
//        else
//        {
//            __instance.m_BotRechargingEnabled = !JSONUtils.GetAsBool(Node, "BotEnergyEnabled", false);
//        }
//        __instance.m_BotLimitEnabled = JSONUtils.GetAsBool(Node, "BotLimitEnabled", false);
//        __instance.m_MapSeed = JSONUtils.GetAsInt(Node, "Seed", 0);
//        __instance.m_MapName = JSONUtils.GetAsString(Node, "Name", "Tim");
//        __instance.m_StartPosition.Load(Node, "StartPosition", default(TileCoord));

//        //m_Sizes
//        //TODO maybe create Save extension method for Vector2Int and Vector2Int array?
//        JSONArray asArray = JSONUtils.GetAsArray(Node, "Sizes");
//        if (asArray != null)
//        {
//            int num = 0;
//            int num1 = 0;
//            while (num < asArray.Count)
//            {
//                int asInt = asArray[num].AsInt;
//                num++;
//                int asInt2 = asArray[num].AsInt;
//                num++;
//                __instance.m_Sizes[num1] = new Vector2Int(asInt, asInt2);
//                num1++;
//            }
//        }

//        return false;
//    }
//}
