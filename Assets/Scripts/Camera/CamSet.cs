using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSet : MonoBehaviour {
    public float Width = 1280.0f;
    public float Height = 720.0f;
    private Camera m_Camera = null;

    private void Awake()
    {
        m_Camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Screen.width / Screen.height >= Width / Height)
        {
            m_Camera.orthographicSize = Height / Screen.height;
        }
        else
        {
            m_Camera.orthographicSize = Width / Screen.width;
        }
    }
}
