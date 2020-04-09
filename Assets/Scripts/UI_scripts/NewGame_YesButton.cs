using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class NewGame_YesButton : MonoBehaviour
{
    public void InvokeYes()
    {
        File.Delete(Application.persistentDataPath + "/Data.dat");
        StartCoroutine(NewGame());

    }
    IEnumerator NewGame()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("LoadingScene");
    }
}
