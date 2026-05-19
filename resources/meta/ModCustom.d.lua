---@meta Autonauts

-----@class ModCustomCallback
--ModCustomCallback = {}
-----Callback return
-----@param Type string # Type of custom item - UniqueName
-----@param LocationX integer # 
-----@param LocationY integer # 
-----@param ItemUniqueID integer # ItemUniqueID the item's uniqueID
-----@param UserUniqueID integer # UserUniqueID of the user of Worker/Player/ConverterAddedTo etc.
--function ModCustomCallback:Callback(Type, LocationX, LocationY, ItemUniqueID, UserUniqueID) end

---@class ModCustom
ModCustom = {}

---@alias CallbackType 'FoodConsumed' | 'ClothingTopAdded' | 'ClothingTopRemoved' | 'ClothingHatAdded' | 'ClothingHatRemoved' | 'ConverterCreateItem' | 'ConverterComplete' | 'HoldablePickedUp' | 'HoldableDroppedOnGround' | 'AddedToConverter' | 'BuildingRenamed' | 'BuildingRepositioned'

--- Register a callback on specific events for a custom item
---@param UniqueName string # The unique and corresponding name of the object - Required
---@param CallbackType CallbackType # The type of callback to register for - Required
---@param Callback fun(Type: string, LocationX: integer, LocationY: integer, ItemUniqueID: integer, UserUniqueID: integer) # The function to callback to on event - Required
function ModCustom.RegisterForCustomCallback(UniqueName, CallbackType, Callback) end

--- Update custom model parameters (All parameters - scale, rotation and translation)
---@param UniqueName string # The unique and corresponding name of the object - Required
---@param Scale number # Scale of the model - Defaults to 1
---@param RotX number # Rotation (X) of the model - Defaults to 0
---@param RotY number # Rotation (Y) of the model - Defaults to 0
---@param RotZ number # Rotation (Z) of the model - Defaults to 0
---@param TransX number # Translation (X) of the model - Defaults to 0
---@param TransY number # Translation (Y) of the model - Defaults to 0
---@param TransZ number # Translation (Z) of the model - Defaults to 0
function ModCustom.UpdateModelParameters(UniqueName, Scale, RotX, RotY, RotZ, TransX, TransY, TransZ) end

--- Update custom model rotation only
---@param UniqueName string # The unique and corresponding name of the object - Required
---@param RotX number # Rotation (X) of the model - Defaults to 0
---@param RotY number # Rotation (Y) of the model - Defaults to 0
---@param RotZ number # Rotation (Z) of the model - Defaults to 0
function ModCustom.UpdateModelRotation(UniqueName, RotX, RotY, RotZ) end

--- Update custom model scale only
---@param UniqueName string # The unique and corresponding name of the object - Required
---@param Scale number # Scale of the model - Defaults to 1
function ModCustom.UpdateModelScale(UniqueName, Scale) end

--- Update custom model scale only (Defining each of the axes)
---@param UniqueName string # The unique and corresponding name of the object - Required
---@param ScaleX number # X Scale of the model - Defaults to 1
---@param ScaleY number # Y Scale of the model - Defaults to 1
---@param ScaleZ number # Z Scale of the model - Defaults to 1
function ModCustom.UpdateModelScaleSplit(UniqueName, ScaleX, ScaleY, ScaleZ) end

--- Update custom model translation only
---@param UniqueName string # The unique and corresponding name of the object - Required
---@param TransX number # Translation (X) of the model - Defaults to 0
---@param TransY number # Translation (Y) of the model - Defaults to 0
---@param TransZ number # Translation (Z) of the model - Defaults to 0
function ModCustom.UpdateModelTranslation(UniqueName, TransX, TransY, TransZ) end

---@alias SubCategory 'Hidden' | 'ToolsLevel1' | 'ToolsLevel2' | 'BotsHeads' | 'BotsBodies' | 'BotsDrives' | 'BotsUpgrades' | 'PartsWood' | 'PartsStone' | 'PartsClay' | 'PartsMetal' | 'FoodMushroom' | 'FoodPumpkin' | 'FoodBerry' | 'FoodApple' | 'FoodCereal' | 'FoodFish' | 'FoodCarrot' | 'FoodOther' | 'ClothingWool' | 'ClothingCotton' | 'ClothingRushes' | 'ClothingHeadwear' | 'ClothingOther' | 'LeisureDoll' | 'LeisureHorse' | 'LeisureOther' | 'Medicine' | 'Education' | 'Art' | 'WildlifeAnimals' | 'WildlifeCrops' | 'Vehicles' | 'Misc' | 'BuildingsWorkshop' | 'BuildingsStorage' | 'BuildingsSpecial' | 'BuildingsFood' | 'BuildingsWalls' | 'BuildingsFloors' | 'BuildingsTrains' | 'BuildingsAnimals' | 'BuildingsClothing' | 'BuildingsMisc' | 'BuildingsDecoration' | 'BuildingsPrizes'| 'Prizes'

--- Sets the subcategory of an item
--- @param UniqueName string
--- @param SubCategory SubCategory
function ModCustom.SetSubCategory(UniqueName, SubCategory) end
