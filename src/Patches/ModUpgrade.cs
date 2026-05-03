using MoonSharp.Interpreter;
using System;
using UnityEngine;

[MoonSharpUserData]
public class ModUpgrade
{
    //TODO: CreateSign
    public void CreateUpgradePlayerInventory(string UniqueName, int Level, int Capacity, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradePlayerInventoryClass.CreateUpgradePlayerInventory(UniqueName, Level, Capacity, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradePlayerMovement(string UniqueName, int Level, float Delay, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradePlayerMovementClass.CreateUpgradePlayerMovement(UniqueName, Level, Delay, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradePlayerWhistle(string UniqueName, int Level, string CallSound, string CancelSound, string DropAllSound, string ToMeSound, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradePlayerWhistleClass.CreateUpgradePlayerWhistle(UniqueName, Level, CallSound, CancelSound, DropAllSound, ToMeSound, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradeWorkerInventory(string UniqueName, int Level, int Capacity, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradeWorkerInventoryClass.CreateUpgradeWorkerInventory(UniqueName, Level, Capacity, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradeWorkerCarry(string UniqueName, int Level, int Capacity, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradeWorkerCarryClass.CreateUpgradeWorkerCarry(UniqueName, Level, Capacity, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradeWorkerEnergy(string UniqueName, int Level, float DriveEnergy, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradeWorkerEnergyClass.CreateUpgradeWorkerEnergy(UniqueName, Level, DriveEnergy, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradeWorkerMemory(string UniqueName, int Level, int Size, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradeWorkerMemoryClass.CreateUpgradeWorkerMemory(UniqueName, Level, Size, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradeWorkerMovement(string UniqueName, int Level, int InitialDelay, float MoveScale, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradeWorkerMovementClass.CreateUpgradeWorkerMovement(UniqueName, Level, InitialDelay, MoveScale, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
    public void CreateUpgradeWorkerSearch(string UniqueName, int Level, int InitialDelay, int Range, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradeWorkerSearchClass.CreateUpgradeWorkerSearch(UniqueName, Level, InitialDelay, Range, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
}
