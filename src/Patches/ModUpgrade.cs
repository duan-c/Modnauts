using MoonSharp.Interpreter;
using System;
using UnityEngine;

[MoonSharpUserData]
public class ModUpgrade : ModCustom
{
    public override void Init()
    {
        base.Init();
    }

    public override string GetPrefabLocation()
    {
        return "WorldObjects/Upgrades/Upgrade";//
    }

    public override ObjectSubCategory GetSubcategory()
    {
        return ObjectSubCategory.BotsUpgrades;
    }

    public override bool GetStackable()
    {
        return true;
    }

    public void CreateUpgradeWorkerMemory(string UniqueName, int Level, int Size, string[] NewIngredientsStringArr = null, int[] NewIngredientsAmountArr = null, string ModelName = "", bool UsingCustomModel = true)
    {
        ModManager.Instance.ModUpgradeWorkerMemoryClass.CreateUpgradeWorkerMemory(UniqueName, Level, Size, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel);
    }
}
