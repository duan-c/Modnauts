using BepInEx.Logging;
using HarmonyLib;
using Modnauts;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ModTool;
using static VariableManager;


[MoonSharpUserData]
public class ModnautDialog
{
    public Script OwnerScript;
    public DynValue CallbackFunction;
    public DynValue CancelFunction;


    public void ShowPopup(string Title, string Description)
    {
        GameStateManager.Instance.PushState(GameStateManager.State.ModsPopup);
        GameStateManager.Instance.GetCurrentState().GetComponent<GameStateModsPopup>().SetInformation(Title, Description);
    }

    public void Ok(string Description)
    {
        GameStateManager.Instance.PushState(GameStateManager.State.OK);
        GameStateManager.Instance.GetCurrentState().GetComponent<GameStateOK>().m_OK
            .SetTitleText(Description);
    }

    public void Confirm(DynValue Callback, string Title, string Description, DynValue Cancel = null)
    {
        ModnautsPlugin.Logger.LogInfo($"ModnautDialog: {Title}");
        GameStateManager.Instance.PushState(GameStateManager.State.Confirm);
        GameStateManager.Instance.GetCurrentState().GetComponent<GameStateConfirm>().SetConfirm(OnConfirm, "ConfirmBotLimit", "ConfirmBotLimitDescription", OnConfirmCancel);
        GameStateManager.Instance.GetCurrentState().GetComponent<GameStateConfirm>().m_Menu
            .transform.Find("BasePanelOptions").Find("Panel/TitleStrip/Title").GetComponent<BaseText>()
            .SetText(Title);
        GameStateManager.Instance.GetCurrentState().GetComponent<GameStateConfirm>().m_Menu
            .transform.Find("BasePanelOptions").Find("Description").GetComponent<BaseText>()
            .SetText(Description);
        OwnerScript = ModManager.Instance.GetLastCalledScript();
        CallbackFunction = Callback;
        CancelFunction = Cancel;
    }
    public void OnConfirm()
    {
        ModnautsPlugin.Logger.LogInfo("ModnautDialog: Yes");
        if (CallbackFunction != DynValue.Void)
        {
            DynValue[] args = new DynValue[0]
            {
                //DynValue.NewNumber(Info.m_Actioner.m_UniqueID),
                //DynValue.NewNumber(Info.m_Position.x),
                //DynValue.NewNumber(Info.m_Position.y),
                //DynValue.NewNumber(num),
                //DynValue.NewString(str)
            };
            //ModManager.Instance.Callback(OwnerScript, Callback, args);
            ModManager.Instance.Callback(OwnerScript, CallbackFunction);
        }
        CallbackFunction = null;
        CancelFunction = null;
    }
    public void OnConfirmCancel()
    {
        ModnautsPlugin.Logger.LogInfo("ModnautDialog: No");
        if (CancelFunction != DynValue.Void)
        {
            ModManager.Instance.Callback(OwnerScript, CancelFunction);
        }
        CallbackFunction = null;
        CancelFunction = null;
    }
}