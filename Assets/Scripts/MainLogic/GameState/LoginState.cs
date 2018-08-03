using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginState : GameState
{
    protected override void OnLoadComplete()
    {
        GUIManager.ShowView("LoginPanel");
    }

    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
        GUIManager.HideView("LoginPanel");
    }
}
