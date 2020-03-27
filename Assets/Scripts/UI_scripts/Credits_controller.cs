using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits_controller : MonoBehaviour
{
    public void BackToStart()
    {
        SceneManager.LoadScene("SceneForTheBeginning");
    }
    void Update()
    {
        if (Input.anyKey)
        {
            BackToStart();
        }
    }

}
