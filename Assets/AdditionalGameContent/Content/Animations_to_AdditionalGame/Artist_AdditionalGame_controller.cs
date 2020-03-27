using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artist_AdditionalGame_controller : MonoBehaviour
{
    private static Artist_AdditionalGame_controller instance = null;
    public static Artist_AdditionalGame_controller Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
