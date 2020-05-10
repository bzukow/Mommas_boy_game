using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_pasta : MonoBehaviour
{
    Character_controller chc;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            chc = collider.GetComponent<Character_controller>();
            chc.bubbleText.GetComponent<TextMesh>().characterSize = 0.4f;
            chc.OpenDialogBubble("Oh well, I dont\nhave pasta on my\nlist... But you never\nknow when the\napocalipse will come");
        }
        
    }

    public void DestroyMe()
    {
        chc = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>();
        chc.bubbleText.GetComponent<TextMesh>().characterSize = 0.5f;
        chc.CloseDialogBubble();
        Destroy(gameObject);
        
    }
}
