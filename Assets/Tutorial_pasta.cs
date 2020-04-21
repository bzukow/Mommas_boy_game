using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_pasta : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Character_controller chc = collider.GetComponent<Character_controller>();
            chc.bubbleText.GetComponent<TextMesh>().characterSize = 0.4f;
            chc.OpenDialogBubble("Oh well, I dont\nhave pasta on my\nlist... But you never\nknow when the\napocalipse will come");
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<Character_controller>().bubbleText.GetComponent<TextMesh>().characterSize = 0.5f;
            collider.GetComponent<Character_controller>().CloseDialogBubble();
            Destroy(transform.GetComponent<BoxCollider>());
        }
    }
}
