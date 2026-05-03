using HarmonyLib;
using Modnauts;
using MoonSharp.Interpreter;
using System.Drawing;
using System.Drawing.Drawing2D;
using UnityEngine;

[HarmonyPatch(typeof(FarmerPlayer))]
[HarmonyPatch("UpdateSpeed")]
class FarmerPlayer_UpdateSpeed
{
    static void Postfix(FarmerPlayer __instance)
    {
        try
        {
            //apply the movement upgrades for custom items.
            var movementUpgrade = __instance.m_FarmerUpgrades.GetMovementUpgrade();
            if (ModManager.Instance.ModUpgradePlayerMovementClass.IsItCustomType(movementUpgrade))
            {
                var m_MoveBaseDelay = Traverse.Create(__instance).Field("m_MoveBaseDelay");
                float num = VariableManager.Instance.GetVariableAsFloat(ObjectType.FarmerPlayer, "BaseDelay");
                num -= VariableManager.Instance.GetVariableAsFloat(movementUpgrade, "Delay");
                Holdable topObject = __instance.m_FarmerCarry.GetTopObject();
                if (topObject != null)
                {
                    int weight = topObject.m_Weight;
                    if (weight == 3)
                    {
                        num += 0.15f;
                    }
                    else if (weight == 4)
                    {
                        num += 0.25f;
                    }
                    else if (weight > 4)
                    {
                        num += 1f;
                    }
                }
                __instance.SetMoveBaseDelay(num);

                //base = 0.200f

                //upgrade 1 = - 0.050f
                //upgrade 2 = - 0.075f
                //upgrade 3 = - 0.100f

                //weight 3 = + 0.150f
                //weight 4 = + 0.250f
                //weight 4+ = + 1.000f

                //tileDelay = - 0.025f,//sand path, or bridge
                //tileDelay = - 0.050f,//stone path, or flooring
                //tileDelay = - 0.075f,//road crude
                //tileDelay = - 0.100f,//road good

                //final delay = base - upgrade + weight - tile delay
                //bare min delay = 0.050f

                //max useful upgrade = - 0.250f which will allow you to walk top speed, fully loaded on rough terrain
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in FarmerPlayer_UpdateSpeed patch: {ex}");
        }
    }
}



[HarmonyPatch(typeof(FarmerPlayer))]
[HarmonyPatch("CreateScooter")]
class FarmerPlayer_CreateScooter
{
    static bool Prefix(FarmerPlayer __instance)
    {
        try
        {
            //by default the Mod models does not get into account.  this fixes it.
            ObjectType movementUpgrade = __instance.m_FarmerUpgrades.GetMovementUpgrade();
            if (ModManager.Instance.ModUpgradePlayerMovementClass.IsItCustomType(movementUpgrade))
            {
                GameObject original = ModelManager.Instance.Load(movementUpgrade, "", false);
                __instance.m_Scooter = InstantiationManager.MyInstantiate(original, __instance.transform.position, Quaternion.identity, null);
                PlaySound m_ScooterSound = AudioManager.Instance.StartEvent("ScooterMove", __instance, true);
                Traverse.Create(__instance).Field("m_ScooterSound").SetValue(m_ScooterSound);
                return false;
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in FarmerPlayer_CreateScooter patch: {ex}");
        }
        return true;
    }
}
