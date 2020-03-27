using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen_LoadButton : MonoBehaviour
{
    public void InvokeLoadLastCheckpoint()
    {
        //w sumie tu po prosu dam zeby wcytac lv od nowa 
        //i wtedy powinno w starcie przeniesc tam gdzie trzeba i elo
        Time.timeScale = 1;
        StartCoroutine(LoadLastCheckpoint());
    }
    IEnumerator LoadLastCheckpoint()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("Level");
    }
}
