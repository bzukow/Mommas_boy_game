using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_norm_alco : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<Character_controller>().OpenDialogBubble("What's that smell?\nBetter prepare\ncigarettes...");
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<Character_controller>().CloseDialogBubble();
            Destroy(transform.GetComponent<BoxCollider>());
        }
    }
}
