using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanel : IView
{
    public PlayerPanel()
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
        Debug.Log("PlayerPanel view Hide");
    }

    public override void OnPress(GameObject sender, object param)
    {
    }

    public override void OnShow()
    {

    }

    public override void OnStart()
    {
        Debug.Log("PlayerPanel view Start");
    }
}
