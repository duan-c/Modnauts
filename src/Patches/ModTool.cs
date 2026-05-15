using HarmonyLib;
using Modnauts;
using MoonSharp.Interpreter;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

public static class ModToolExtensions
{
    extension(ModTool modTool)
    {
        public void CreateBaseTool(string BaseType, string UniqueName, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
        {
            MyTool.Type result = MyTool.Type.Total;
            if (!Enum.TryParse<MyTool.Type>(BaseType, out result))
            {
                string descriptionOverride = "Error: ModTool.CreateBaseTool '" + BaseType + "' - Unknown tool type for base";
                ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
                return;
            }
            switch (result)
            {
                case MyTool.Type.Shovel:
                    CreateShovel(modTool, UniqueName, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
                    return;
                case MyTool.Type.Hoe:
                    CreateHoe(modTool, UniqueName, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
                    return;
                case MyTool.Type.Axe:
                    CreateAxe(modTool, UniqueName, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
                    return;
                case MyTool.Type.Scythe:
                    CreateScythe(modTool, UniqueName, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
                    return;
                case MyTool.Type.Pick:
                    CreatePick(modTool, UniqueName, 0, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
                    return;
                default:
                    string descriptionOverride = "Error: ModTool.CreateBaseTool '" + BaseType + "' - Unknown tool type for base";
                    ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
                    return;
            }
        }

        public void CreateShovel(string UniqueName, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
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
            ModManager.Instance.ModToolClass.SetToolCategoryBase(UniqueName, "Shovel");
            ObjectType modObjectTypeFromName = ModManager.Instance.GetModObjectTypeFromName(UniqueName);
            if (ModelName.Length == 0)
            {
                modTool.ModModels[modObjectTypeFromName] = "Models/Tools/ToolShovel";
            }
            if (GeneralUtils.m_InGame)
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Plot", UniqueName, 16);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Weed", UniqueName, 16);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "CropCarrot", UniqueName, 16);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Bush", UniqueName, 24);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Hedge", UniqueName, 24);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Mushroom", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "FlowerWild", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Grass", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "TreeStump", UniqueName, 20);
                ModManager.Instance.ModVariableClass.SetVariableFarmerActionOnTiles("Shovel", "Empty", UniqueName, 16);
                ModManager.Instance.ModVariableClass.SetVariableFarmerActionOnTiles("Shovel", "Clay", UniqueName, 20);
                ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "MaxUsage", 20);
                ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "NoMultiple", 1);
            }
        }

        public void CreateHoe(string UniqueName, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
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
            ModManager.Instance.ModToolClass.SetToolCategoryBase(UniqueName, "Hoe");
            ObjectType modObjectTypeFromName = ModManager.Instance.GetModObjectTypeFromName(UniqueName);
            if (ModelName.Length == 0)
            {
                modTool.ModModels[modObjectTypeFromName] = "Models/Tools/ToolHoe";
            }
            if (GeneralUtils.m_InGame)
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Hoe", "Plot", UniqueName, 16);
                ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "MaxUsage", 20);
                ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "NoMultiple", 1);
            }
        }

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
            ObjectType modObjectTypeFromName = ModManager.Instance.GetModObjectTypeFromName(UniqueName);
            if (ModelName.Length == 0)
            {
                modTool.ModModels[modObjectTypeFromName] = "Models/Tools/ToolAxe";
            }
            if (GeneralUtils.m_InGame)
            {
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

        public void CreateScythe(string UniqueName, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
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
            ModManager.Instance.ModToolClass.SetToolCategoryBase(UniqueName, "Scythe");
            ObjectType modObjectTypeFromName = ModManager.Instance.GetModObjectTypeFromName(UniqueName);
            if (ModelName.Length == 0)
            {
                modTool.ModModels[modObjectTypeFromName] = "Models/Tools/ToolScythe";
            }
            if (GeneralUtils.m_InGame)
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "CropWheat", UniqueName, 8);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "CropCotton", UniqueName, 8);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "Bullrushes", UniqueName, 8);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "Grass", UniqueName, 10);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "FlowerWild", UniqueName, 5);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "FlowerPot", UniqueName, 5);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "CropPumpkin", UniqueName, 5);
                ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "MaxUsage", 40);
                ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "NoMultiple", 1);
            }
        }

        public void CreatePick(string UniqueName, int Level = 0, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
        {
            try
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
                ModManager.Instance.ModToolClass.SetToolCategoryBase(UniqueName, "Pick");
                ObjectType modObjectTypeFromName = ModManager.Instance.GetModObjectTypeFromName(UniqueName);
                if (ModelName.Length == 0)
                {
                    modTool.ModModels[modObjectTypeFromName] = "Models/Tools/ToolPick";
                }
                if (GeneralUtils.m_InGame)
                {
                    ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Mining", "Plot", UniqueName, 20);
                    ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Mining", "Boulder", UniqueName, 24);
                    ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Mining", "TallBoulder", UniqueName, 24);
                    ModManager.Instance.ModVariableClass.SetVariableFarmerActionOnTiles("Mining", "Iron", UniqueName, 20);
                    ModManager.Instance.ModVariableClass.SetVariableFarmerActionOnTiles("Mining", "Coal", UniqueName, 20);
                    ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "MaxUsage", 20);
                    ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "NoMultiple", 1);
                    ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "Level", Level);//using Tier variable increases model size
                }
            }
            catch (Exception ex)
            {
                ModManager.Instance.WriteModError("ModTool.CreatePick Error: " + ex.ToString());
                ModnautsPlugin.Logger.LogError($"Error in ModTool.CreatePick patch: {ex}");
            }
        }
    }
    /* TODO:
        Type.Bucket;
        Type.Mallet;
        Type.Chisel;
        Type.Flail;
        Type.Shears;
        Type.WateringCan;
        Type.FishingRod;
        Type.Broom;
        Type.Pitchfork;
        Type.Torch;
        Type.Dredger;
        Type.Net;
        Type.Blade;
    */
}
