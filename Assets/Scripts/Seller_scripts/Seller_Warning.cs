using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller_Warning : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<Character_controller>().OpenDialogBubble("Uff... Finally\nit's the end...");
        }

    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<Character_controller>().CloseDialogBubble();
        }
    }
}
