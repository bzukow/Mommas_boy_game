using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cigarette_attack : MonoBehaviour
{
    private Rigidbody rigid;
    private GameObject player;

    public bool thrown;
    public float time;

    void Start()
    {

        rigid = transform.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        rigid.useGravity = true;
    }

    void Update()
    {
        if (thrown)
        {
            thrown = false;
            transform.GetComponent<BoxCollider>().enabled = true;
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>().facingLeft)
            {
                rigid.AddForce(new Vector3(-400 * time, 200 * time, 0));
            }
            else
            {
                rigid.AddForce(new Vector3(400*time,200*time, 0));
            }
            
            Invoke("DestroyCigarette", 3);
        }
    }
    
    public void ThrowCigarette(float throwingTime)
    {
        time = throwingTime;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>().canAttack = true;
        transform.parent = null;
        thrown = true;
    }

    void DestroyCigarette()
    {
        if (player.GetComponent<Character_controller>().lastCigarette)
        {
            //wyswietl dymek i zakoncz gre 
            player.GetComponent<Character_controller>().OpenDialogBubble("Oh no, I forgot about\nsaving one for myself\nlater! Nothing makes\nsense right now...");
        }
        Destroy(gameObject);
    }
}
