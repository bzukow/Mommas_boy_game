using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardController : MonoBehaviour
{
    public Sprite cardFace;
    public BoxCollider boxcollider;
    public Animator animator;
    public MainController mainController;
    private AudioSource audios;
    Text counterText;
     void Start()
    {
        audios = GetComponent<AudioSource>();
        counterText = GameObject.FindGameObjectWithTag("Counter").GetComponent<Text>();
        mainController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        boxcollider = transform.GetComponent<BoxCollider>();
        animator = transform.GetComponent<Animator>();
    }
    void OnMouseDown()
    {
        audios.Play();
        animator.SetBool("isChosen", true);
        boxcollider.enabled = false;

        if (mainController.counter % 3 == 0)
        {
            mainController.firstChosen = this;
        } else if(mainController.counter % 3 == 1)
        {
            mainController.secondChosen = this;
        } else
        {
            mainController.thirdChosen = this;
        }
        
        mainController.counter++;
        counterText.text = "Moves: " + mainController.counter;
    }
}
