using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI层级
/// </summary>
public enum UIPanelLayers
{
    BackgroundLayer = 0,
    DefaultLayer = 10,
    NormalLayer = 20,
    MainLayer = 30,
    MaskLayer = 40,
    PopupLayer = 50,
    TipsLayer = 60,
    PromptLayer = 70,
    LoadingLayer = 80,
}

public abstract class IView
{
    /// <summary>
    /// 层级
    /// </summary>
    public UIPanelLayers layer = UIPanelLayers.NormalLayer;

    public void Start()
    {
        OnStart();
    }

    public void Destory()
    {
        OnDestory();
    }

    public void Show()
    {
        OnShow();
    }

    public void Hide()
    {
        OnHide();
    }

    public void Click(GameObject sender, object param)
    {
        OnClick(sender, param);
    }

    public void Press(GameObject sender, object param)
    {
        OnPress(sender, param);
    }

    public void Drag(GameObject sender, object param)
    {
        OnDrag(sender, param);
    }

    public virtual void Update() { }

    // 这个地方可能需要一个Awake，靠构造函数还是有点不靠谱；上面的Start调用时机又太晚了
    public abstract void OnStart();
    public abstract void OnDestory();
    public abstract void OnShow();
    public abstract void OnHide();
    public abstract void OnClick(GameObject sender, object param);
    public abstract void OnPress(GameObject sender, object param);
    public abstract void OnDrag(GameObject sender, object param);
}
