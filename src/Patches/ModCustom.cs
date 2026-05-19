using HarmonyLib;
using Modnauts;
using System;
using System.Collections.Generic;

public static class ModCustomExtensions
{
    extension(ModCustom modCustom)
    {
        public void SetSubCategory(string UniqueName, string SubCategory)
        {
            try
            {
                ObjectType Identifier = ObjectType.Nothing;
                if (!Enum.TryParse<ObjectType>(UniqueName, out Identifier))
                {
                    Identifier = ModManager.Instance.GetModObjectTypeFromName(UniqueName);
                }
                if (Identifier == ObjectType.Nothing)
                {
                    string descriptionOverride = "Error: ModCustom.SetItemSubCategory '" + UniqueName + "' - Not Found";
                    ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
                    return;
                }

                ObjectSubCategory NewCategory = ObjectSubCategory.Hidden;
                if (!Enum.TryParse<ObjectSubCategory>(SubCategory, out NewCategory))
                {
                    string descriptionOverride = "Error: ModCustom.SetItemSubCategory '" + SubCategory + "' - Not Found";
                    ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
                    return;
                }
                ObjectTypeList.Instance.EnableCustomItem(Identifier, NewCategory);
            }
            catch (Exception ex)
            {
                ModManager.Instance.WriteModError("ModCustom.SetCustomItemSubCategory Error: " + ex.ToString());
            }
        }
    }
}