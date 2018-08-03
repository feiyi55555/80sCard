using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryMe : MonoBehaviour {
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
