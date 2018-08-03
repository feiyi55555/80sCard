using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GUIManager
{
    private static Dictionary<string, KeyValuePair<GameObject, IView>> m_UIViewDic = new Dictionary<string, KeyValuePair<GameObject, IView>>();

    public static GameObject InstantiatePanel(string panelName)
    {
        GameObject prefab = ResourcesManager.Instance.GetUIPrefab(panelName);
        if (prefab == null) return null;
        GameObject panel = GameObject.Instantiate(prefab);
        panel.name = panelName;

        Camera uiCam = GameObject.FindWithTag("UICamera").GetComponent<Camera>();
        if (uiCam == null)
        {
            Debug.LogError("Wrong UI Cam");
            return null;
        }

        panel.transform.SetParent(uiCam.transform);
        panel.transform.localScale = Vector3.one;
        panel.transform.localPosition = Vector3.zero;

        return panel;
    }

    public static void ShowView(string panelName)
    {
        IView view = null;
        GameObject panel = null;

        KeyValuePair<GameObject, IView> pair;
        if (!m_UIViewDic.TryGetValue(panelName, out pair))
        {
            // 字典里没有
            view = Assembly.GetExecutingAssembly().CreateInstance(panelName) as IView; // 这里就要求，IView和对应的Panel名字必须一样
            panel = InstantiatePanel(panelName); // 实例化一个Panel

            if (view == null || panel == null)
            {
                return;
            }
            UIPanel[] childPanels = panel.GetComponentsInChildren<UIPanel>(true);
            for (int i = 0; i < childPanels.Length; i++)
            {
                childPanels[i].depth += (int)view.layer;
            }
            m_UIViewDic.Add(panelName, new KeyValuePair<GameObject, IView>(panel, view));

            view.Start();
        }
        else
        {
            view = pair.Value;
            panel = pair.Key;
        }


        if (view == null || panel == null)
        {
            return;
        }

        HideSameLayerPanel(view);

        UIPanel uiPanel = panel.GetComponent<UIPanel>();
        uiPanel.alpha = 1;

        panel.SetActive(true);
        view.Show();
    }

    /// <summary>
    /// 隐藏同LayerPanel
    /// </summary>
    /// <param name="view">视图控制器</param>
    /// <param name="isInclusive">是否顺便隐藏自己</param>
    public static void HideSameLayerPanel(IView view, bool isInclusive = false)
    {
        foreach (var pair in m_UIViewDic)
        {
            if (view.layer == pair.Value.Value.layer &&
                pair.Value.Key.activeSelf)
            {
                if (!isInclusive && view == pair.Value.Value)
                {
                    continue;
                }
                HideView(pair.Key);
            }
        }
    }

    public static void HideView(string panelName)
    {
        KeyValuePair<GameObject, IView> pair;
        if (!m_UIViewDic.TryGetValue(panelName, out pair))
        {
            return;
        }

        pair.Key.SetActive(false);
        pair.Value.Hide();
    }
}
