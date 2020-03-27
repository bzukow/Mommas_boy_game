﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_chilli : MonoBehaviour
{
    public GameObject check;
    public Character_controller player;

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
                player.canCollect = false;
                Invoke("Collect", 0.1f);
            }
        }
    }
    void Collect()
    {

        if ((player.chilli = player.chilli - 1) == 0)
        {
            check.SetActive(true);
        }
        Destroy(transform.parent.gameObject);
        //zagraj animacje jakas plz 
        player.canCollect = true;
    }
}
