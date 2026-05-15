---@meta Autonauts

---@class ModText
ModText = {}

--- Sets the display name of an object
---@param TextID string # The unique and corresponding name of the object - Required
---@param Text string # The new text - Required
---@param ModText? boolean # Default true - Optional
function ModText.SetText(TextID, Text, ModText) end

--- Sets the description of an object
---@param UniqueName string # The unique and corresponding name of the object - Required
---@param Description string # The new description - Required
function ModText.SetDescription(UniqueName, Description) end
