using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager
{
    private static ResourcesManager _instance;
    public static ResourcesManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ResourcesManager();
            return _instance;
        }
    }

    private string uiPrefabPath = "UI/Panel";
    public GameObject GetUIPrefab(string name)
    {
        return LoadPrefab(name, uiPrefabPath);
    }

    private GameObject LoadPrefab(string name, string path)
    {
        string loadPath = path + "/" + name;
        GameObject prefab = Resources.Load(loadPath, typeof(GameObject)) as GameObject;
        if (prefab == null) Debug.LogError("loadPath failed! path:" + loadPath);
        return prefab;
    }

    private string XMLPath = "Config";
    public TextAsset LoadConfigXML(string name)
    {
        return LoadXMLAsset(name, XMLPath);
    }

    private TextAsset LoadXMLAsset(string name, string path)
    {
        TextAsset textAsset = null;
        string loadPath = path + "/" + name;
        textAsset = Resources.Load(loadPath, typeof(TextAsset)) as TextAsset;
        if (textAsset == null)
        {
            Debug.LogError("loadPath failed! path:" + loadPath);
        }
        return textAsset;
    }
}