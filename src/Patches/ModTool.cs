using HarmonyLib;
using Modnauts;
using System.Collections.Generic;

public static class ModToolExtensions
{
    extension(ModTool modTool)
    {
        public void SetToolLevel(string UniqueName, int Level = 1)
        {
            ObjectType objectType = ObjectType.Nothing;
            foreach (KeyValuePair<ObjectType, string> modIDOriginal in modTool.ModIDOriginals)
            {
                if (modIDOriginal.Value.Equals(UniqueName))
                {
                    objectType = modIDOriginal.Key;
                }
            }
            if (objectType == ObjectType.Nothing)
            {
                string descriptionOverride = "Error: ModTool.SetToolLevel '" + UniqueName + "' - Custom Tool Not Recognised";
                ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
                return;
            }
            MyTool.Type toolType = MyTool.GetType(objectType);
            if (toolType == MyTool.Type.Total)
            {
                string descriptionOverride = "Error: ModTool.SetToolLevel '" + UniqueName + "' - Custom Tool has no Base Category";
                ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
                return;
            }
            switch (toolType)
            {
                case MyTool.Type.Shovel:
                    modTool.SetShovelLevel(UniqueName, Level);
                    return;
                case MyTool.Type.Hoe:
                    modTool.SetHoeLevel(UniqueName, Level);
                    return;
                case MyTool.Type.Axe:
                    modTool.SetAxeLevel(UniqueName, Level);
                    return;
                case MyTool.Type.Scythe:
                    modTool.SetScytheLevel(UniqueName, Level);
                    return;
                case MyTool.Type.Pick:
                    modTool.SetPickLevel(UniqueName, Level);
                    return;
                case MyTool.Type.Blade:
                    modTool.SetBladeLevel(UniqueName, Level);
                    return;
                default:
                    return;
            }
        }

        private void SetShovelLevel(string UniqueName, int Level)
        {
            ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "Level", Level);
            if (Level < 1)//Stick
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Plot", UniqueName, 20);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Weed", UniqueName, 24);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "CropCarrot", UniqueName, 24);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Bush", UniqueName, 32);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Hedge", UniqueName, 32);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Mushroom", UniqueName, 20);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "FlowerWild", UniqueName, 20);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Grass", UniqueName, 20);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "TreeStump", UniqueName, 0);
                ModManager.Instance.ModVariableClass.SetVariableFarmerActionOnTiles("Shovel", "Empty", UniqueName, 0);
                ModManager.Instance.ModVariableClass.SetVariableFarmerActionOnTiles("Shovel", "Clay", UniqueName, 0);
            }
            else if (Level < 2)//ToolShovelStone
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
            }
            else//ToolShovel
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Plot", UniqueName, 8);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Weed", UniqueName, 8);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "CropCarrot", UniqueName, 8);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Bush", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Hedge", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Mushroom", UniqueName, 6);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "FlowerWild", UniqueName, 6);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "Grass", UniqueName, 6);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Shovel", "TreeStump", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerActionOnTiles("Shovel", "Empty", UniqueName, 8);
                ModManager.Instance.ModVariableClass.SetVariableFarmerActionOnTiles("Shovel", "Clay", UniqueName, 12);
            }
        }
        private void SetHoeLevel(string UniqueName, int Level)
        {
            ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "Level", Level);
            if (Level < 2)//ToolHoeStone
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Hoe", "Plot", UniqueName, 16);
            }
            else//ToolHoe
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Hoe", "Plot", UniqueName, 8);
            }
        }
        private void SetAxeLevel(string UniqueName, int Level)
        {
            ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "Level", Level);
            if (Level < 1)//Rock
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreePine", UniqueName, 32);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreeApple", UniqueName, 32);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreeCoconut", UniqueName, 32);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreeMulberry", UniqueName, 32);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "Log", UniqueName, 0);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "Plank", UniqueName, 0);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "Pole", UniqueName, 0);
            }
            else if (Level < 2)//ToolAxeStone
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreePine", UniqueName, 24);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreeApple", UniqueName, 24);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreeCoconut", UniqueName, 24);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreeMulberry", UniqueName, 24);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "Log", UniqueName, 16);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "Plank", UniqueName, 16);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "Pole", UniqueName, 12);
            }
            else//ToolAxe
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreePine", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreeApple", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreeCoconut", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "TreeMulberry", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "Log", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "Plank", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "Pole", UniqueName, 6);
            }
        }
        private void SetScytheLevel(string UniqueName, int Level)
        {
            ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "Level", Level);
            if (Level < 2)//ToolScytheStone
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "CropWheat", UniqueName, 10);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "CropCotton", UniqueName, 10);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "Bullrushes", UniqueName, 10);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "Grass", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "FlowerWild", UniqueName, 6);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "FlowerPot", UniqueName, 6);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "CropPumpkin", UniqueName, 6);
            }
            else//ToolScythe
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "CropWheat", UniqueName, 6);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "CropCotton", UniqueName, 6);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "Bullrushes", UniqueName, 6);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "Grass", UniqueName, 6);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "FlowerWild", UniqueName, 4);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "FlowerPot", UniqueName, 4);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "CropPumpkin", UniqueName, 4);
            }
        }
        private void SetPickLevel(string UniqueName, int Level)
        {
            ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "Level", Level);
            if (Level < 1)//Rock
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Mining", "Plot", UniqueName, 0);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Mining", "Boulder", UniqueName, 32);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Mining", "TallBoulder", UniqueName, 32);
                ModManager.Instance.ModVariableClass.SetVariableFarmerActionOnTiles("Mining", "Iron", UniqueName, 0);
                ModManager.Instance.ModVariableClass.SetVariableFarmerActionOnTiles("Mining", "Coal", UniqueName, 0);
            }
            else if (Level < 2)//ToolPickStone
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Mining", "Plot", UniqueName, 20);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Mining", "Boulder", UniqueName, 24);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Mining", "TallBoulder", UniqueName, 24);
                ModManager.Instance.ModVariableClass.SetVariableFarmerActionOnTiles("Mining", "Iron", UniqueName, 20);
                ModManager.Instance.ModVariableClass.SetVariableFarmerActionOnTiles("Mining", "Coal", UniqueName, 20);
            }
            else//ToolPick
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Mining", "Plot", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Mining", "Boulder", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Mining", "TallBoulder", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerActionOnTiles("Mining", "Iron", UniqueName, 12);
                ModManager.Instance.ModVariableClass.SetVariableFarmerActionOnTiles("Mining", "Coal", UniqueName, 12);
            }
        }
        private void SetBladeLevel(string UniqueName, int Level)
        {
            ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(UniqueName, "Level", Level);
            if (Level < 1)//RockSharp
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "CropWheat", UniqueName, 18);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "CropCotton", UniqueName, 18);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "Bullrushes", UniqueName, 18);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "Grass", UniqueName, 16);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "FlowerWild", UniqueName, 0);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "FlowerPot", UniqueName, 0);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "CropPumpkin", UniqueName, 0);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "FishAny", UniqueName, 10);
            }
            else//ToolBlade
            {
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "CropWheat", UniqueName, 8);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "CropCotton", UniqueName, 8);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "Bullrushes", UniqueName, 8);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "Grass", UniqueName, 10);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "FlowerWild", UniqueName, 5);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "FlowerPot", UniqueName, 5);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Scythe", "CropPumpkin", UniqueName, 5);
                ModManager.Instance.ModVariableClass.SetVariableFarmerAction("Chopping", "FishAny", UniqueName, 5);
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
    */
}


[HarmonyPatch(typeof(ModTool))]
[HarmonyPatch("SetToolCategoryBase")]
class ModTool_SetToolCategoryBase
{
    static void Postfix(ModTool __instance, string UniqueName, string BaseType)
    {
        try
        {
            if (GeneralUtils.m_InGame)
            {
                __instance.SetToolLevel(UniqueName);
            }
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in ModTool_SetToolCategoryBase patch: {ex}");
        }
    }
}
