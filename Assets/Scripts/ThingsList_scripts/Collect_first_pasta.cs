using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_first_pasta : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Character_controller chc = collider.GetComponent<Character_controller>();
            chc.bubbleText.GetComponent<TextMesh>().characterSize = 0.4f;
            chc.OpenDialogBubble("Oh well, I dont\nhave pasta on my\nlist... But you never\nknow when the\napocalipse will come");
            collider.GetComponent<Character_controller>().checkpoint = transform.parent.position;
            transform.parent.gameObject.tag = "Untagged";
            GameObject.FindGameObjectWithTag("Saver").GetComponent<Save_Load_Controller>().SaveGame();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>().bubbleText.GetComponent<TextMesh>().characterSize = 0.5f;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>().CloseDialogBubble();
        Destroy(transform.parent.gameObject);
    }
}
