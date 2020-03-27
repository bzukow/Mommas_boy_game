using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBool_AG : MonoBehaviour
{
    private static MyBool_AG instance = null;
    public static MyBool_AG Instance
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
