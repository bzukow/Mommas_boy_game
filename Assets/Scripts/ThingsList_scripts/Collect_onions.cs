using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_onions : MonoBehaviour
{
    public Character_controller player;
    //trzeba w moomencie zapisu ogarnac
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (player.canCollect)
            {
                player.canCollect = false;
                Invoke("Collect", 0.1f);
            }
        }
    }
    void Collect()
    {
        player.onions--;
        Destroy(transform.parent.gameObject);
        //zagraj animacje jakas plz 
        player.canCollect = true;
    }
    void TurnOnBoxCollider()
    {
        transform.GetComponent<BoxCollider>().enabled = true;
    }
}
