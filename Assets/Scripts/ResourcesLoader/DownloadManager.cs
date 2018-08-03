using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DownloadManager : MonoBehaviour // 为了使用协程所以不得不继承Mono
{
    private static DownloadManager _instance;
    public static DownloadManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(DownloadManager)) as DownloadManager;
            }
            return _instance;
        }
    }

    private float m_DownProgress = 0.0f;
    public float DownLoadProgress
    {
        get
        {
            return (int) (m_DownProgress * 100) / 100.0f;
        }
    }

    public delegate void LoadCallBack(params object[] args);
    public void LoadScene(string name, LoadCallBack loadHandler, params object[] args)
    {
        StartCoroutine(CoLoadSceneBundle(name, loadHandler, args));
    }

    AsyncOperation async = null;
    private IEnumerator CoLoadSceneBundle(string name, LoadCallBack loadHandler, params object[] args)
    {
        async = SceneManager.LoadSceneAsync(name);
        yield return async;
        Resources.UnloadUnusedAssets();
        GC.Collect();
        Debug.Log(name + "  Scene is loaded");
        if (loadHandler != null)
        {
            loadHandler(args);
        }
        async = null;
    }

    // 进度条委托
    public delegate void DelegateProgress(float progress, string fileName);
    public event DelegateProgress UpdateProgressEvent;

    private void Update()
    {
        if (async != null)
        {
            m_DownProgress = async.progress;
            if (UpdateProgressEvent != null)
            {
                UpdateProgressEvent(m_DownProgress, "");
            }
        }
    }
}
