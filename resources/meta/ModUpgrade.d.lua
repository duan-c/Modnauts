---@meta Modnauts

--- This class handles upgrades. The actual implementation
--- lives in the Modnauts BepInEx plugin.
---@class ModUpgrade : ModCustom
ModUpgrade = {}

--- Creates a new Player Inventory Upgrade
---@param UniqueName string # The unique and corresponding name of the upgrade - Required
---@param Capacity integer # The amount of slots to increase player inventory by
---@param NewIngredientsStringArr string[] # List of ingredients required to make the upgrade - Defaults to none
---@param NewIngredientsAmountArr integer[] # The amount of each of the ingredients (Must match size of ingredients array) - Defaults to none
---@param ModelName string # The name/path of the custom model to use or name/path of the in game model to use - Defaults to in game 'UpgradePlayerInventoryCrude' Model
---@param UsingCustomModel boolean # True if using a custom model, false if using in game model/default model - Defaults to true
function ModUpgrade.CreateUpgradePlayerInventory(UniqueName, Capacity, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel) end

--- Creates a new Player Movement Upgrade
---@param UniqueName string # The unique and corresponding name of the upgrade - Required
---@param Delay number # Crude = 0.050, Good = 0.075, Super = 0.100, Max = 0.250
---@param NewIngredientsStringArr string[] # List of ingredients required to make the upgrade - Defaults to none
---@param NewIngredientsAmountArr integer[] # The amount of each of the ingredients (Must match size of ingredients array) - Defaults to none
---@param ModelName string # The name/path of the custom model to use or name/path of the in game model to use - Defaults to in game 'UpgradePlayerMovementCrude' Model
---@param UsingCustomModel boolean # True if using a custom model, false if using in game model/default model - Defaults to true
function ModUpgrade.CreateUpgradePlayerMovement(UniqueName, Delay, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel) end

--- Creates a new Player Whistle Upgrade
---@param UniqueName string # The unique and corresponding name of the upgrade - Required
---@param CallSound string # The sound event name
---@param CancelSound string # The sound event name
---@param DropAllSound string # The sound event name
---@param ToMeSound string # The sound event name
---@param NewIngredientsStringArr string[] # List of ingredients required to make the upgrade - Defaults to none
---@param NewIngredientsAmountArr integer[] # The amount of each of the ingredients (Must match size of ingredients array) - Defaults to none
---@param ModelName string # The name/path of the custom model to use or name/path of the in game model to use - Defaults to in game 'UpgradePlayerWhistleCrude' Model
---@param UsingCustomModel boolean # True if using a custom model, false if using in game model/default model - Defaults to true
function ModUpgrade.CreateUpgradePlayerWhistle(UniqueName, CallSound, CancelSound, DropAllSound, ToMeSound, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel) end

--- Creates a new Bot Inventory Upgrade
---@param UniqueName string # The unique and corresponding name of the upgrade - Required
---@param Capacity integer # The amount of slots to increase bot inventory by
---@param NewIngredientsStringArr string[] # List of ingredients required to make the upgrade - Defaults to none
---@param NewIngredientsAmountArr integer[] # The amount of each of the ingredients (Must match size of ingredients array) - Defaults to none
---@param ModelName string # The name/path of the custom model to use or name/path of the in game model to use - Defaults to in game 'UpgradeWorkerInventoryCrude' Model
---@param UsingCustomModel boolean # True if using a custom model, false if using in game model/default model - Defaults to true
function ModUpgrade.CreateUpgradeWorkerInventory(UniqueName, Capacity, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel) end

--- Creates a new Bot Carry Upgrade
---@param UniqueName string # The unique and corresponding name of the upgrade - Required
---@param Capacity integer # The amount of slots to increase bot carry capacity by
---@param NewIngredientsStringArr string[] # List of ingredients required to make the upgrade - Defaults to none
---@param NewIngredientsAmountArr integer[] # The amount of each of the ingredients (Must match size of ingredients array) - Defaults to none
---@param ModelName string # The name/path of the custom model to use or name/path of the in game model to use - Defaults to in game 'UpgradeWorkerCarryCrude' Model
---@param UsingCustomModel boolean # True if using a custom model, false if using in game model/default model - Defaults to true
function ModUpgrade.CreateUpgradeWorkerCarry(UniqueName, Capacity, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel) end

--- Creates a new Bot Energy Upgrade
---@param UniqueName string # The unique and corresponding name of the upgrade - Required
---@param DriveEnergy number # Crude = 0.2, Good = 0.4, Super = 0.6
---@param NewIngredientsStringArr string[] # List of ingredients required to make the upgrade - Defaults to none
---@param NewIngredientsAmountArr integer[] # The amount of each of the ingredients (Must match size of ingredients array) - Defaults to none
---@param ModelName string # The name/path of the custom model to use or name/path of the in game model to use - Defaults to in game 'UpgradeWorkerEnergyCrude' Model
---@param UsingCustomModel boolean # True if using a custom model, false if using in game model/default model - Defaults to true
function ModUpgrade.CreateUpgradeWorkerEnergy(UniqueName, DriveEnergy, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel) end

--- Creates a new Bot Memory Upgrade
---@param UniqueName string # The unique and corresponding name of the upgrade - Required
---@param Size integer # Extra KB - Crude = 4, Good = 8, Super = 32
---@param NewIngredientsStringArr string[] # List of ingredients required to make the upgrade - Defaults to none
---@param NewIngredientsAmountArr integer[] # The amount of each of the ingredients (Must match size of ingredients array) - Defaults to none
---@param ModelName string # The name/path of the custom model to use or name/path of the in game model to use - Defaults to in game 'UpgradeWorkerMemoryCrude' Model
---@param UsingCustomModel boolean # True if using a custom model, false if using in game model/default model - Defaults to true
function ModUpgrade.CreateUpgradeWorkerMemory(UniqueName, Size, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel) end

--- Creates a new Bot Movement Upgrade
---@param UniqueName string # The unique and corresponding name of the upgrade - Required
---@param InitialDelay integer # Crude = 20, Good = 40, Super = 60
---@param MoveScale integer # Crude = 0.1, Good = 0.2, Super = 0.3
---@param NewIngredientsStringArr string[] # List of ingredients required to make the upgrade - Defaults to none
---@param NewIngredientsAmountArr integer[] # The amount of each of the ingredients (Must match size of ingredients array) - Defaults to none
---@param ModelName string # The name/path of the custom model to use or name/path of the in game model to use - Defaults to in game 'UpgradeWorkerMovementCrude' Model
---@param UsingCustomModel boolean # True if using a custom model, false if using in game model/default model - Defaults to true
function ModUpgrade.CreateUpgradeWorkerMovement(UniqueName, InitialDelay, MoveScale, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel) end 

--- Creates a new Bot Search Upgrade
---@param UniqueName string # The unique and corresponding name of the upgrade - Required
---@param InitialDelay integer # Crude = 10, Good = 20, Super = 30
---@param Range integer # Crude = 5, Good = 10, Super = 15
---@param NewIngredientsStringArr string[] # List of ingredients required to make the upgrade - Defaults to none
---@param NewIngredientsAmountArr integer[] # The amount of each of the ingredients (Must match size of ingredients array) - Defaults to none
---@param ModelName string # The name/path of the custom model to use or name/path of the in game model to use - Defaults to in game 'UpgradeWorkerSearchCrude' Model
---@param UsingCustomModel boolean # True if using a custom model, false if using in game model/default model - Defaults to true
function ModUpgrade.CreateUpgradeWorkerSearch(UniqueName, InitialDelay, Range, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel) end

--- Creates a new Sign
---@param UniqueName string # The unique and corresponding name of the upgrade - Required
---@param Range integer # Normal = 16, Billboard = 20, Good = 35
---@param NewIngredientsStringArr string[] # List of ingredients required to make the upgrade - Defaults to none
---@param NewIngredientsAmountArr integer[] # The amount of each of the ingredients (Must match size of ingredients array) - Defaults to none
---@param ModelName string # The name/path of the custom model to use or name/path of the in game model to use - Defaults to in game 'Sign' Model
---@param UsingCustomModel boolean # True if using a custom model, false if using in game model/default model - Defaults to true
function ModUpgrade.CreateSign(UniqueName, Range, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel) end

--- Sets the level of an upgrade
---@param UniqueName string # The unique and corresponding name of the upgrade - Required
---@param Level integer # Crude = 0, Good = 1, Super = 2
function ModUpgrade.SetUpgradeLevel(UniqueName, Level) end
