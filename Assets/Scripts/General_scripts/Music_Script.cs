using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Script : MonoBehaviour
{
    private static Music_Script instance = null;
    public static Music_Script Instance
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
