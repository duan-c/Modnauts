using Modnauts;

public static class ToolBladeExtensions
{
    extension(ToolBlade toolBlade)
    {
        public static bool GetIsTypeBlade(ObjectType NewType)
        {
            try
            {
                if (MyTool.GetType(NewType) == MyTool.Type.Blade)
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                ModnautsPlugin.Logger.LogError($"Error in ToolBlade_GetIsTypeBlade patch: {ex}");
            }
            return false;
        }
    }
}