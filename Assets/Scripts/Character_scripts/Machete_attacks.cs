using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machete_attacks : MonoBehaviour
{
    private AudioSource[] audios;
    public Animator playerAnim;

    void Start()
    {
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightAlt) && GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>().canAttack
            && GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("isGrounded"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>().canAttack = false;
            playerAnim.SetBool("isMacheteAttack", true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>().stunned = true;
            BoxCollider[] boxcolliders = transform.GetComponents<BoxCollider>();
            foreach (BoxCollider bc in boxcolliders)
            {
                bc.enabled = true;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Beret"))
        {
            collider.GetComponent<Deadly_hat>().moveUp = false;
        }
    }
    
}
