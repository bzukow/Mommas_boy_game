using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Last_Way : MonoBehaviour
{
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            transform.GetComponent<BoxCollider>().isTrigger = false;
            collider.GetComponent<Character_controller>().canAttack = true;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<Character_controller>().canAttack = false;
        }
    }
}
