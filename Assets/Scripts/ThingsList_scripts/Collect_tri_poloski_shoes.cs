﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_tri_poloski_shoes : MonoBehaviour
{
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
        player.tri_poloski_shoes--;
        GameObject.FindGameObjectWithTag("Music_save").GetComponent<AudioSource>().Play();
        Destroy(transform.parent.gameObject);
        player.canCollect = true;
    }
}
