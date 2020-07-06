﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_toilet_paper : MonoBehaviour
{
    public GameObject check;
    public Character_controller player;
    //trzeba w moomencie zapisu ogarnac
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (player.canCollect)
            {
                //TU
                player.transform.parent.SetParent(transform.parent.parent);
                transform.parent.parent.GetComponent<Take_To_End_Platform>().moveUp = true;

                player.canCollect = false;
                Invoke("Collect", 0.1f);
            }
        }
    }
    void Collect()
    {

        if ((player.toilet_paper = player.toilet_paper - 1) == 0)
        {
            check.SetActive(true);
        }
        GameObject.FindGameObjectWithTag("Music_save").GetComponent<AudioSource>().Play();
        Destroy(transform.parent.gameObject);
        player.canCollect = true;
    }
}
