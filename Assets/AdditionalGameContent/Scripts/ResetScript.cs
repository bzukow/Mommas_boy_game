using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetScript : MonoBehaviour
{
    GameObject gameController;
    Text counterText;
    AudioSource audios;
    void Start(){
        audios = GetComponent<AudioSource>();
        transform.GetComponent<Button>().interactable = false;
        gameController = GameObject.FindGameObjectWithTag("GameController");
        counterText = GameObject.FindGameObjectWithTag("Counter").GetComponent<Text>();
    }
    // Start is called before the first frame update
    public void ResetGame()
    {
        audios.Play();
        gameController.GetComponent<MainController>().counter = 0;
        gameController.GetComponent<MainController>().numberOfPairs = 0;
        foreach (Transform child in gameController.transform)
        {
            child.GetComponent<Animator>().SetBool("isPaired", false);
            child.GetComponent<Animator>().SetBool("isChosen", false);
            child.GetComponent<BoxCollider>().enabled = true;
        }
        Invoke("ChangeCards", 0.5f);
        counterText.text = "Moves: 0";
    }

    void ChangeCards(){
        gameController.GetComponent<MainController>().Fill();
    }
}
