//using HarmonyLib;
//using Modnauts;
//using System;
//using static CeremonyManager;

///// <summary>
///// Skips the CommsIntro and Go ceremonies if we're in a custom world.
///// </summary>
//[HarmonyPatch(typeof(CeremonyManager))]
//[HarmonyPatch("AddCeremony")]
//[HarmonyPatch(new Type[] { typeof(CeremonyType) })]
//class CeremonyManager_AddCeremony
//{
//    static bool Prefix(CeremonyType NewType)
//    {
//        if (ModnautsPlugin.ModnautWorldClass.IsCustomWorld())
//        {
//            if (NewType == CeremonyType.CommsIntro || NewType == CeremonyType.Go)
//            {
//                return false;
//            }
//        }
//        return true;
//    }
//}
