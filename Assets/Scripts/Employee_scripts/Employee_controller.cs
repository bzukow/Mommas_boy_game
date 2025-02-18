﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Employee_controller : MonoBehaviour
{
    GameObject player;
    Animator anim;
    Animator anim_player;
    bool walking;
    public bool playerSeen;
    public bool hadToTurn;
    public bool waitWithAnotherCaught;
    public GameObject[] colliders;
    public GameObject bubbleText;
    public GameObject graphic_container;
    public Transform[] particleSystems;
    public bool hasStopper;
    public bool stopCollider;
    AudioSource[] audiosources;
    //public bool canTakeLives;
    // Start is called before the first frame update
    void Start()
    {
        audiosources = GetComponents<AudioSource>();
        foreach (Transform particleSystem in particleSystems)
        {
            particleSystem.GetComponent<ParticleSystem>().Stop();
        }
        player = GameObject.FindGameObjectWithTag("Player");
        anim = transform.GetComponent<Animator>();
        anim_player = player.GetComponent<Animator>();
    }
    bool seen;
    // Update is called once per frame
    void Update()
    {
        bubbleText.transform.parent.position = new Vector3(transform.position.x, bubbleText.transform.parent.position.y, bubbleText.transform.parent.position.z);
        if (walking)
        {
            transform.position += transform.forward * Time.deltaTime * 4f;
        }
        if (playerSeen)
        {
            if (anim_player.GetBool("isCreepingDown"))
            {
                if (seen)
                {
                    ChangeDirection();
                    seen = false;
                }
                bubbleText.transform.parent.GetComponent<SpriteRenderer>().enabled = false;
                bubbleText.GetComponent<MeshRenderer>().enabled = false;

                anim.SetBool("CharacterHasBeenSeen", false);
                transform.GetComponent<CapsuleCollider>().enabled = false;
            } else if (!anim_player.GetBool("isGrounded")) {
                if (seen)
                {
                    ChangeDirection();
                    seen = false;
                }
                bubbleText.transform.parent.GetComponent<SpriteRenderer>().enabled = false;
                bubbleText.GetComponent<MeshRenderer>().enabled = false;

                anim.SetBool("CharacterHasBeenSeen", false);
                transform.GetComponent<CapsuleCollider>().enabled = false;
            } else
            {
                bubbleText.transform.parent.GetComponent<SpriteRenderer>().enabled = true;
                bubbleText.GetComponent<MeshRenderer>().enabled = true;

                walking = false;
                anim.SetBool("CharacterHasBeenSeen", true);
                seen = true;
                if (!anim.GetBool("CharacterHasBeenCaught") && !waitWithAnotherCaught)
                {
                    transform.position += transform.forward * Time.deltaTime * 7f;
                    transform.GetComponent<CapsuleCollider>().enabled = true;
                }
            }
        }
        else
        {
            bubbleText.transform.parent.GetComponent<SpriteRenderer>().enabled = false;
            bubbleText.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    public void Death()
    {
        if (bubbleText != null)
        {
            Destroy(bubbleText.transform.parent.gameObject);
        }
        Destroy(puffDying.gameObject);
        Destroy(transform.parent.gameObject);

    }
    public void ChangeDirection()
    {
        transform.Rotate(0, 180, 0);
    }
    public void StopCollider()
    {
        if (hasStopper)
        {
            stopCollider = !stopCollider;
        }
    }
    public void ReleasePlayer()
    {
        audiosources[0].Stop();
        foreach (Transform particleSystem in particleSystems)
        {
            particleSystem.GetComponent<ParticleSystem>().Stop();
        }
        if (graphic_container != null)
        {
            graphic_container.SetActive(false);
        }
        if (player.GetComponent<Character_controller>().lives < 1)
        {
            bubbleText.GetComponent<TextMesh>().text = "Feel free to visit\nus again!";
            anim_player.SetBool("isDead", true);
            anim.SetBool("CharacterHasBeenSeen", false);
        } else
        {
            
            bubbleText.GetComponent<TextMesh>().text = "WHY YOU REJECTED\nME I'M GOING TO\nCALL THE POLICE";
            anim_player.SetBool("isParalised", false);
            SwitchOffColliders();
            transform.GetComponent<CapsuleCollider>().enabled = false;
            anim.SetBool("isDestroyed", true);
            
        }
    }
    public void CatchPlayer()
    {
        audiosources[0].Play();
        foreach (Transform particleSystem in particleSystems)
        {
            particleSystem.GetComponent<ParticleSystem>().Play();
        }
        if (graphic_container != null)
        {
            graphic_container.SetActive(true);
        }
        
        bubbleText.GetComponent<TextMesh>().text = "bla bla\nbla bla bla\nbla bla";
        anim_player.SetBool("isParalised", true);
        player.GetComponent<Character_controller>().Stunned();
        anim.SetBool("CharacterHasBeenSeen", false);
        waitWithAnotherCaught = true;
        player.GetComponent<Character_controller>().canTakeLives = true;
        player.GetComponent<Character_controller>().DisplayLessLives();
    }

    void StopBeingTouched()
    {
       anim.SetBool("isTouched", false);
        
    }

    void Walking()
    {
        walking = true;
    }


    void StopWalking()
    {
        transform.Rotate(0, 180, 0);
        walking = false;
        
    }
    public void SwitchOffColliders()
    {
        foreach(GameObject collider in colliders)
        {
            Destroy(collider);
        }
    }
    public ParticleSystem puffDying;
    public void WaitAndDelete()
    {
        
        puffDying.transform.SetParent(null);
        puffDying.Play();
    }
    public GameObject mushrooms;
    public void TurnOffMesh()
    {
        if (mushrooms != null)
        {
            mushrooms.transform.SetParent(null);
            mushrooms.transform.position = new Vector3(mushrooms.transform.position.x-2f, mushrooms.transform.position.y+1f, mushrooms.transform.position.z+1f);
            mushrooms.SetActive(true);
        }
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
    }
    public void SoundDeath()
    {
        audiosources[0].Stop();
        audiosources[1].Play();
    }
}
