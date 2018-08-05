using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityState : GameState
{
    protected override void OnLoadComplete()
    {
        GUIManager.ShowView("PlayerPanel"); // state和panel在此处形成了耦合，可以配表
    }

    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
        GUIManager.HideView("PlayerPanel");
    }
}
