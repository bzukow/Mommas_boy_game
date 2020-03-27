using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits_Button : MonoBehaviour
{
    // Start is called before the first frame update
    public void InvokeShowCredits()
    {
        StartCoroutine(ShowCredits());
    }
    IEnumerator ShowCredits()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("Credits");
    }
}
