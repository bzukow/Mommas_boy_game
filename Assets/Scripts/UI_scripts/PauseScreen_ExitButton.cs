using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen_ExitButton : MonoBehaviour
{
    public void InvokeExitToMenu()
    {
        Time.timeScale = 1;
        StartCoroutine(ExitToMenu());
    }
    IEnumerator ExitToMenu()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("SceneForTheBeginning");
    }
}
