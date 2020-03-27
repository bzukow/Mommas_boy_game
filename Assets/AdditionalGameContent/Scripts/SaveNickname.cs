using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SaveNickname : MonoBehaviour
{
    public void SendNicknameToMainScript()
    {
        MainController mc = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        mc.playerAndValue.Add(new KeyValuePair<string, int>(transform.GetChild(2).GetComponent<Text>().text, mc.counter));
        mc.Save();
        foreach (Transform child in GameObject.FindGameObjectWithTag("GameController").transform)
        {
            child.GetComponent<Animator>().SetBool("isPaired", false);
            child.GetComponent<Animator>().SetBool("isChosen", false);
            child.GetComponent<BoxCollider>().enabled = true;
        }
        transform.parent.parent.gameObject.SetActive(false);
        Invoke("LoadNewScene", 0.5f);
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene("AdditionalGame");
    }
}
