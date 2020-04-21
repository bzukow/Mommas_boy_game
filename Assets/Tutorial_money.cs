using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_money : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<Character_controller>().OpenDialogBubble("I can't spend money given\nfrom my mum...So gotta look\naround and see if someone\nlost their change...\nFinders keepers,\nlosers weepers");
            collider.GetComponent<Character_controller>().ChangeDialogBubbleFontSize(10);
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
