using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftOpening : MonoBehaviour
{
    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            transform.GetComponent<Animator>().SetBool("Opening", true);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            transform.GetComponent<Animator>().SetBool("Opening", false);
        }
    }
}
