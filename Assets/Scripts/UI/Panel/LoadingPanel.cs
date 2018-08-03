using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPanel : IView
{
    public LoadingPanel()
    {
        layer = UIPanelLayers.LoadingLayer;
    }

    private void UpdateProgressEvent(float progress, string fileName)
    {
        // TODO：进度条
    }

    public override void OnClick(GameObject sender, object param)
    {
         
    }

    public override void OnDestory()
    {
        DownloadManager.Instance.UpdateProgressEvent -= UpdateProgressEvent;
    }

    public override void OnDrag(GameObject sender, object param)
    {
         
    }

    public override void OnHide()
    {
        Debug.Log("LoadingPanel view Hide");
    }

    public override void OnPress(GameObject sender, object param)
    {
         
    }

    public override void OnShow()
    {
         
    }

    public override void OnStart()
    {
        Debug.Log("LoadingPanel view Start");
        DownloadManager.Instance.UpdateProgressEvent += UpdateProgressEvent;
    }
}
