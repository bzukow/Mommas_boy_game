using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alco_fog_controller : MonoBehaviour
{
    Transform player;
    Animator animator;
    bool left;
    public Transform graphicContainer;

    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider collider)
    {
        //show C key
        if (collider.CompareTag("Player"))
        {
            if(graphicContainer != null)
            {
                graphicContainer.gameObject.SetActive(true);
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (graphicContainer != null)
            {
                graphicContainer.gameObject.SetActive(false);
            }
        }
        if (other.CompareTag("Player") && !left)
        {
            other.transform.GetComponent<Animator>().SetBool("isInSmoke", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !left)
        {
            left = true;
            Invoke("WaitWithDebuff", 6);
        }
    }

    //void Update()
    //{
        //jesli dostanie fajka to usunale moze to w fajku u zioma? zagrac w ogoole foga ja sie 
        //chowa czy cos, albo jakies puff i wtedy destroy w animatorze 
    //}

    void WaitWithDebuff()
    {
        left = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>().canAttack = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isInSmoke", false);
    }
}
