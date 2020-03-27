using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    GameObject sittingArtist;
    GameObject myBool;
    public void InvokeExitToMenu()
    {
        sittingArtist = Artist_AdditionalGame_controller.Instance.gameObject;
        myBool = MyBool_AG.Instance.gameObject;
        myBool.SetActive(true);
        StartCoroutine(ExitToMenu());
    }
    IEnumerator ExitToMenu()
    {
        
        myBool.SetActive(true);
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading_AG>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        FindObjectOfType<Fading_AG>().isEnding = true;
        SceneManager.LoadScene("SceneForTheBeginning");
    }
}
