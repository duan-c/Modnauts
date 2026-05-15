using HarmonyLib;
using Modnauts;
using Steamworks;
using static BurnableInfo;

[HarmonyPatch(typeof(FarmerStateMining))]
[HarmonyPatch("GetWillToolMineDown")]
class FarmerStateMining_GetWillToolMineDown
{
    static bool Prefix(ObjectType HeldObjectType, Tile.TileType TileType, ref bool __result)
    {
        try
        {
            //      level 0 -> 3
            //          0 = Crude Pick : 
            //          1 = Crude Metal Pick :

            //Level 0: "TileIronSoil","Trace Metal Ore Deposits",
            //Level 1: "TileIronSoil2","Metal Ore Deposits",
            //Level 2: "TileIron","Rich Metal Ore Deposits",

            //Level 0: "TileClaySoil","Clay Deposits",
            //Level 1: "TileClay","Rich Clay Deposits",

            //Level 0: "TileCoalSoil","Trace Coal Deposits",
            //Level 1: "TileCoalSoil2","Coal Deposits",
            //Level 2: "TileCoalSoil3","Rich Coal Deposits",
            //Level 3: "TileCoal","Pure Coal Deposits",

            //Level 0: "TileStoneSoil","Stone Deposits",
            //Level 1: "TileStone","Rich Stone Deposits",

            var level = 0;
            if (HeldObjectType == ObjectType.ToolPickStone) { level = 0; }
            if (HeldObjectType == ObjectType.ToolPick) { level = 1; }
            if (ModManager.Instance.ModToolClass.IsItCustomType(HeldObjectType)) {
                level = VariableManager.Instance.GetVariableAsInt(HeldObjectType, "Level", false);
            }

            if (HeldObjectType == ObjectTypeList.m_Total)
            {
                __result =  false;
                return false;
            }
            if (TileType == Tile.TileType.IronSoil && level < 1)
            {
                __result = false;
                return false;
            }
            if (TileType == Tile.TileType.IronSoil2 && level < 2)
            {
                __result = false;
                return false;
            }
            if (TileType == Tile.TileType.StoneSoil && level < 1)
            {
                __result = false;
                return false;
            }
            if (TileType == Tile.TileType.ClaySoil && level < 1)
            {
                __result = false;
                return false;
            }
            if (TileType == Tile.TileType.CoalSoil && level < 1)
            {
                __result = false;
                return false;
            }
            if (TileType == Tile.TileType.CoalSoil2 && level < 2)
            {
                __result = false;
                return false;
            }
            if (TileType == Tile.TileType.CoalSoil3 && level < 3)
            {
                __result = false;
                return false;
            }
            __result = true;
        }
        catch (System.Exception ex)
        {
            ModnautsPlugin.Logger.LogError($"Error in FarmerStateMining_GetWillToolMineDown patch: {ex}");
        }
        return false;
    }
}
