using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        AddComponent();
    }

    private void AddComponent()
    {
        gameObject.AddComponent<DownloadManager>();
        gameObject.AddComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
