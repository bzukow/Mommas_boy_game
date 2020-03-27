using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending_character_controller : MonoBehaviour
{
    public RightArm_TakingAlco armScritp;
    public bool canEnd;
    public Button endButton;
    void Start()
    {
        Invoke("ActivateButton", 6f);
    }
    public void TakeAlco()
    {
        armScritp.TakeAlco();
    }
    public void PutAlco()
    {
        armScritp.PutAlco();
    }
    public void SwitchOnEnd()
    {
        
        StartCoroutine(Exit());
        
    }
    void ActivateButton()
    {
        endButton.interactable = true;
    }
    IEnumerator Exit()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("SceneForTheBeginning");
    }
}
