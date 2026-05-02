using Modnauts;
using MoonSharp.Interpreter;


[MoonSharpUserData]
public class ModnautLogger
{
    public void LogDebug(object data)
    {
        ModnautsPlugin.Logger.LogDebug(data);
    }
    public void LogInfo(object data)
    {
        ModnautsPlugin.Logger.LogInfo(data);
    }    
    public void LogMessage(object data)
    {
        ModnautsPlugin.Logger.LogMessage(data);
    }
    public void LogWarning(object data)
    {
        ModnautsPlugin.Logger.LogWarning(data);
    }
    public void LogError(object data)
    {
        ModnautsPlugin.Logger.LogError(data);
    }
    public void LogFatal(object data)
    {
        ModnautsPlugin.Logger.LogFatal(data);
    }
}