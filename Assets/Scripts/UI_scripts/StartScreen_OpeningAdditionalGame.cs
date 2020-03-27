using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen_OpeningAdditionalGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void OpenAdditionalGame()
    {
        StartCoroutine(AdditionalGame());
    }

    IEnumerator AdditionalGame()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("AdditionalGame");
    }
}
