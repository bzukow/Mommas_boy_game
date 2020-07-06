using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_first_pasta : MonoBehaviour
{
    public Tutorial_pasta tp;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Music_save").GetComponent<AudioSource>().Play();
            collider.GetComponent<Character_controller>().checkpoint = transform.parent.position;
            tp.gameObject.tag = "Untagged";
            transform.parent.gameObject.tag = "Untagged";
            GameObject.FindGameObjectWithTag("Saver").GetComponent<Save_Load_Controller>().SaveGame();
            tp.DestroyMe();
            Destroy(transform.parent.gameObject);
        }
    }
    
}
