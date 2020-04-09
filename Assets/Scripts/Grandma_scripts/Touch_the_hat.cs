using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_the_hat : MonoBehaviour
{
    public Grandma_controller gc;
    // Start is called before the first frame update
    void Update()
    {
        if (gc)
        {
            transform.position = gc.transform.position;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (gc)
        {
            if (collider.CompareTag("Player") && !GameObject.FindGameObjectWithTag("Beret") && !gc.anim.GetBool("isDead"))
            {
                gc.anim.SetBool("isThrowing", true);
            }
        }
    }
        void OnTriggerExit(Collider collider)
    {
        if (gc)
        {
            if (collider.CompareTag("Player"))
            {
                if (gc.anim.GetBool("isThrowing"))
                {
                    gc.anim.SetBool("isThrowing", false);
                    gc.canMove = true;
                }
                if (GameObject.FindGameObjectWithTag("Beret"))
                {
                    GameObject.FindGameObjectWithTag("Beret").GetComponent<Deadly_hat>().moveUp = false;
                }
            }
        }
       
    }
}
