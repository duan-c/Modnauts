---@meta Autonauts

---@class ModDebug
ModDebug = {}

--- Clears the Debug log output file
function ModDebug.ClearLog() end

--- Logs information to the Debug log output file
---@param args any[] # Any data requiring logging
function ModDebug.Log(args) end

---@alias LogLevel 'Fatal' | 'Error' | 'Warning' | 'Message' | 'Info' | 'Debug'

--- Logs information to the BepInEx console
---@param level LogLevel # Log level to attach to the message
---@param args any[] # Any data requiring logging
function ModDebug.LogConsole(level, args) end
