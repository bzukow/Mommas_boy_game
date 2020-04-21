using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_first_pasta : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<Character_controller>().checkpoint = transform.parent.position;
            transform.parent.gameObject.tag = "Untagged";
            GameObject.FindGameObjectWithTag("Saver").GetComponent<Save_Load_Controller>().SaveGame();

            Destroy(transform.parent.gameObject);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        Destroy(transform.parent.gameObject);
    }
}
