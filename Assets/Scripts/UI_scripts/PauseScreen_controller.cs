using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseScreen_controller : MonoBehaviour
{
    public bool isClicked;
    public GameObject pauseScreenElements;

    GameObject pauseScreen;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            if (!isClicked && Time.timeScale == 1)
            {
                pauseScreen = Instantiate(pauseScreenElements, transform);
                isClicked = true;
                Time.timeScale = 0;

            } else if(isClicked && Time.timeScale == 0)
            {
                HidePauseMenu();
            }
            
        }
    }
    public void HidePauseMenu()
    {
        Time.timeScale = 1;
        isClicked = false;
        Destroy(pauseScreen);
    }
}
