using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public bool customSpeed;
    public Vector2 customVelocity;
    public float multiplier;

    bool onTop;
    public GameObject bouncer;
    Animator anim;
    Vector2 velocity;
    public bool tryHere;
    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (onTop)
        {
            anim.SetBool("isStepped", true);
            bouncer = other.gameObject;
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTop = true;
            //other.transform.parent.SetParent(transform);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTop = false;
            anim.SetBool("isStepped", false);
            bouncer.GetComponent<Character_controller>().canAttack = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTop = true;
        }
    }

    void Jump()
    {
        GetComponent<AudioSource>().Play();
        Character_controller chc = bouncer.GetComponent<Character_controller>();
        if (chc.inAir)
        {
            chc.inAir = false;
        }
        chc.canAttack = false;

        rb = bouncer.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, multiplier, 0), ForceMode.Impulse);
    }
    Rigidbody rb;
}
