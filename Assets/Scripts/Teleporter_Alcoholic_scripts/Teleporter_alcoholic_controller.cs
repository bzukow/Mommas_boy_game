﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter_alcoholic_controller : MonoBehaviour
{
    public Transform target;
    public float isTriggered = 0;
    private bool eaten = false;
    private bool dont = true;
    public Transform graphicContainer;
    public GameObject bubbleText;
    public string textInside;
    public float firstTime;
    public float alreadyUsed;

    void Start()
    {
        textInside = bubbleText.GetComponent<TextMesh>().text;
        firstTime = 1;
        alreadyUsed = 0;
    }
    void OnTriggerStay(Collider collider)
    {

        if (collider.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                if (alreadyUsed == 1)
                {
                    bubbleText.GetComponent<TextMesh>().text = "Here we go again!";
                    Invoke("Teleport", 2f);
                } else
                {
                    float amountCoins = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>().coins;
                    if (amountCoins >= 10 && !eaten)
                    {
                        if (firstTime == 0)
                        {
                            GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>().coins -= 13;
                            bubbleText.GetComponent<TextMesh>().text = "You see? It was't\nthat hard.\nPrepare yourself for\nsome magic...";

                        }
                        else
                        {
                            GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>().coins -= 12;
                            bubbleText.GetComponent<TextMesh>().text = "World needs such\na good people like\nyou... Here's some magic\nfor you";
                        }
                        //audios[1].Play();
                        eaten = true;
                        dont = false;
                        Invoke("Teleport", 2f);
                        Invoke("Eaten", 1);

                    }
                    else if (dont)
                    {
                        bubbleText.GetComponent<TextMesh>().text = "Nothing for free boy,\ncome back when you\ngrow up";
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            graphicContainer.gameObject.SetActive(true);
            bubbleText.transform.parent.GetComponent<SpriteRenderer>().enabled = true;
            bubbleText.GetComponent<MeshRenderer>().enabled = true;
            if (firstTime == 0)
            {
                bubbleText.GetComponent<TextMesh>().text = "You again? You should\nbe faster, now it's\n13 coins.";
            }
            if (alreadyUsed == 1)
            {
                bubbleText.GetComponent<TextMesh>().text = "Oh hi, haven't expected\nyou here. If you\nwant I can help you again,\nthis time without money.";
            }

        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            graphicContainer.gameObject.SetActive(false);
            bubbleText.transform.parent.GetComponent<SpriteRenderer>().enabled = false;
            bubbleText.GetComponent<MeshRenderer>().enabled = false;
            if (firstTime == 1)
            {
                firstTime = 0;
            }
        }
    }
    void Eaten()
    {
        eaten = false;
    }
    void Teleport()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = target.position;
        alreadyUsed = 1;
    }
}
