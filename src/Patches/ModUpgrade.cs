using MoonSharp.Interpreter;
using System;
using UnityEngine;

[MoonSharpUserData]
public class ModUpgrade
{
    public void CreateUpgradeWorkerMemory(string UniqueName, int Level, int Size, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradeWorkerMemoryClass.CreateUpgradeWorkerMemory(UniqueName, Level, Size, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
}
