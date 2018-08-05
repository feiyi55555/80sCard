using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginPanel : IView
{
    public LoginPanel()
    {
        layer = UIPanelLayers.NormalLayer;
    }

    public override void OnClick(GameObject sender, object param)
    {
        if (sender.gameObject.name.Equals("LoginBtn"))
        {
            GameStateManager.LoadScene(2);
        }
    }

    public override void OnDestory()
    {
    }

    public override void OnDrag(GameObject sender, object param)
    {
    }

    public override void OnHide()
    {
        Debug.Log("LoginPanel view Hide");
    }

    public override void OnPress(GameObject sender, object param)
    {
    }

    public override void OnShow()
    {

    }

    public override void OnStart()
    {
        Debug.Log("LoginPanel view Start");
    }
}
