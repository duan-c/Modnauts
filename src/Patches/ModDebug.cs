using BepInEx.Logging;
using Modnauts;
using MoonSharp.Interpreter;
using System;
using System.Text.RegularExpressions;

public static class ModDebugExtensions
{
    extension(ModDebug modDebug)
    {
        public void LogConsole(string level, params object[] args)
        {
            LogLevel result = LogLevel.None;
            if (!Enum.TryParse<LogLevel>(level, out result))
            {
                string descriptionOverride = "Error: ModDebug.LogConsole '" + level + "' - Unknown log level";
                ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
                return;
            }
            Script lastCalledScript = ModManager.Instance.GetLastCalledScript();
            if (lastCalledScript != null && Regex.IsMatch(lastCalledScript.Globals["_ModDisplayName"].ToString(), "\\D"))
            {
                string text = "";
                DynValue[] array = new DynValue[args.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = DynValue.FromObject(lastCalledScript, args[i]);
                    text += array[i].ToPrintString();
                }
                ModnautsPlugin.Logger.Log(result, text);
            }
        }
    }
}