---@meta Autonauts

---@class ModTool : ModCustom
ModTool = {}

--- Create a custom tool item, one the player can pickup and use on defined objects
---@param UniqueName string # The unique and corresponding name of the tool - Required
---@param NewIngredientsStringArr string[] # List of ingredients required to make the upgrade - Defaults to none
---@param NewIngredientsAmountArr integer[] # The amount of each of the ingredients (Must match size of ingredients array) - Defaults to none
---@param ObjectsToUseOnArr string[] # List of objects this tool works on - Defaults to none
---@param TilesToUseOnArr string[] # List of tiles this tool works on - Defaults to none
---@param ObjectsToProduceArr string[] # List of objects to produce once tool has been used - Defaults to none
---@param ObjectsToProduceAmountArr integer[] # Amount of each object to produce once tool has been used - Defaults to none
---@param AnimationDuration number # How long the animation lasts - Defaults to 2 seconds (2.0f)
---@param ModelName string # The name/path of the custom model to use or name/path of the in game model to use - Defaults to in game 'Axe' Model
---@param UsingCustomModel boolean # True if using a custom model, false if using in game model/default model - Defaults to true
---@param CallbackOnComplete function # The function to callback when the tool action is complete [Param 1 is the Unique ID of the Bot/Farmer/User, Param 2 is TileLocation X, Param 3 is Y] - Defaults to none
---@param DestroyTarget boolean # Destroy the target object once completed - Defaults to true
function ModTool.CreateTool(UniqueName, NewIngredientsStringArr, NewIngredientsAmountArr, ObjectsToUseOnArr, TilesToUseOnArr, ObjectsToProduceArr, ObjectsToProduceAmountArr, AnimationDuration, ModelName, UsingCustomModel, CallbackOnComplete, DestroyTarget) end

--- Create a custom axe
---@param UniqueName string # The unique and corresponding name of the tool - Required
---@param NewIngredientsStringArr string[] # List of ingredients required to make the upgrade - Defaults to none
---@param NewIngredientsAmountArr integer[] # The amount of each of the ingredients (Must match size of ingredients array) - Defaults to none
---@param ModelName string # The name/path of the custom model to use or name/path of the in game model to use - Defaults to in game 'Axe' Model
---@param UsingCustomModel boolean # True if using a custom model, false if using in game model/default model - Defaults to true
function ModTool.CreateAxe(UniqueName, NewIngredientsStringArr, NewIngredientsAmountArr, ModelName, UsingCustomModel) end
