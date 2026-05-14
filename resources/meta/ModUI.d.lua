---@meta Autonauts

---@class ModUI
ModUI = {}

--- Show a UI Popup with a desired title and description
---@param Title string # Title to be displayed - Required
---@param Description string # Description to be displayed (Will scroll if needed) - Required
function ModUI.ShowPopup(Title, Description) end

--- Show a UI Popup with a desired title, description, OK/Cancel buttons and Callbacks
---@param Title string # Title to be displayed - Required
---@param Description string # Description to be displayed (Will scroll if needed) - Required
---@param CallbackOK function # Callback function to be called when 'OK/Tick/Yes' is hit - Required
---@param CallbackCancel function # Callback function to be called when 'Cancel/No' is hit - Required
function ModUI.ShowPopupConfirm(Title, Description, CallbackOK, CallbackCancel) end

