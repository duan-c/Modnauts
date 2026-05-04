using MoonSharp.Interpreter;
using System;
using UnityEngine;

[MoonSharpUserData]
public class ModUpgrade
{
    //TODO: CreateSign
    public void CreateUpgradePlayerInventory(string UniqueName, int Capacity, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradePlayerInventoryClass.CreateUpgradePlayerInventory(UniqueName, 0, Capacity, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradePlayerMovement(string UniqueName, float Delay, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradePlayerMovementClass.CreateUpgradePlayerMovement(UniqueName, 0, Delay, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradePlayerWhistle(string UniqueName, string CallSound, string CancelSound, string DropAllSound, string ToMeSound, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradePlayerWhistleClass.CreateUpgradePlayerWhistle(UniqueName, 0, CallSound, CancelSound, DropAllSound, ToMeSound, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradeWorkerInventory(string UniqueName, int Capacity, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradeWorkerInventoryClass.CreateUpgradeWorkerInventory(UniqueName, 0, Capacity, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradeWorkerCarry(string UniqueName, int Capacity, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradeWorkerCarryClass.CreateUpgradeWorkerCarry(UniqueName, 0, Capacity, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradeWorkerEnergy(string UniqueName, float DriveEnergy, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradeWorkerEnergyClass.CreateUpgradeWorkerEnergy(UniqueName, 0, DriveEnergy, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradeWorkerMemory(string UniqueName, int Size, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradeWorkerMemoryClass.CreateUpgradeWorkerMemory(UniqueName, 0, Size, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradeWorkerMovement(string UniqueName, int InitialDelay, float MoveScale, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradeWorkerMovementClass.CreateUpgradeWorkerMovement(UniqueName, 0, InitialDelay, MoveScale, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradeWorkerSearch(string UniqueName, int InitialDelay, int Range, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradeWorkerSearchClass.CreateUpgradeWorkerSearch(UniqueName, 0, InitialDelay, Range, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }

    public void SetUpgradeLevel(string NewTypeString, int Level)
    {
        ObjectType result = ObjectType.Nothing;
        if (!Enum.TryParse<ObjectType>(NewTypeString, out result))
        {
            result = ModManager.Instance.GetModObjectTypeFromName(NewTypeString);
        }

        if (result == ObjectType.Nothing)
        {
            string descriptionOverride = "Error: ModUpgrade.SetUpgradeLevel '" + NewTypeString + "' - Not Found";
            ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
            return;
        }
        if (!Upgrade.GetIsTypeUpgrade(result))
        {
            string descriptionOverride = "Error: ModUpgrade.SetUpgradeLevel '" + NewTypeString + "' - Not Upgrade";
            ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
            return;
        }
        VariableManager.Instance.SetVariable(result, "Level", Level);
        //ModManager.Instance.ModVariableClass.SetVariableForObjectAsInt(NewTypeString, "Level", Level);
    }
}
