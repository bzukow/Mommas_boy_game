using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_money : MonoBehaviour
{
    Character_controller chc;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            chc = collider.GetComponent<Character_controller>();
            chc.OpenDialogBubble("I can't spend money given\nfrom my mum...So gotta look\naround and see if someone\nlost their change...\nFinders keepers,\nlosers weepers");
            chc.ChangeDialogBubbleFontSize(10);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            chc.CloseDialogBubble();
            Destroy(gameObject);
        }
    }
    public void DestroyMe()
    {
        if (chc)
        {
            chc.CloseDialogBubble();
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
