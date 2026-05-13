using HarmonyLib;
using Modnauts;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;

public static class ModToolExtensions
{
    extension(ModTool modTool)
    {
        public void CreateAxe(string UniqueName, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
        {
            modTool.CreateTool(
                UniqueName,
                NewIngredientsStringArr,
                NewIngredientsAmountArr,
                null,
                null,
                null,
                null,
                2,
                ModelName,
                UsingCustomModel,
                null,
                true);
            ModManager.Instance.ModToolClass.SetToolCategoryBase(UniqueName, "Axe");
            ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreePine", UniqueName, 24);
            ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreeApple", UniqueName, 24);
            ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreeCoconut", UniqueName, 24);
            ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreeMulberry", UniqueName, 24);
            ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "Log", UniqueName, 16);
            ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "Plank", UniqueName, 16);
            ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "Pole", UniqueName, 12);
            ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "MaxUsage", 20);
            ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "NoMultiple", 1);
        }
    }
/*

---@alias MyToolType 'Axe' | 'Basket' | 'Broom' | 'Bucket' | 'Chisel' | 'Dredger' | 'FishingRod' | 'Flail' | 'Hoe' | 'Mallet' | 'Paddle' | 'Pick' | 'Pitchfork' | 'Scythe' | 'Shears' | 'Shovel' | 'Torch' | 'WateringCan' | 'Net' | 'Blade'

--- Sets the base type of a custom tool to enable default behaviour for that type
---@param UniqueName string # The unique and corresponding name of the tool - Required
---@param BaseType MyToolType # Type of tool
function ModTool.SetToolCategoryBase(UniqueName, BaseType) end
*/

}
