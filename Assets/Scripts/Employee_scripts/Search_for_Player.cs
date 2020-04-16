using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search_for_Player : MonoBehaviour
{
    GameObject player;
    public Employee_controller employee;
    Animator anim_player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim_player = player.GetComponent<Animator>();
    }
    void Update()
    {
        if (employee.hasStopper)
        {
            if (!employee.stopCollider)
            {
                transform.position = employee.transform.position;
            }
        } else
        {
            transform.position = employee.transform.position;
        }
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            employee.playerSeen = true;

            if (!player.GetComponent<Animator>().GetBool("isCreepingDown") && (player.transform.eulerAngles.y > 265 && employee.transform.eulerAngles.y > 265)
                    || (player.transform.eulerAngles.y < 93 && employee.transform.eulerAngles.y < 93))
            {
                employee.transform.Rotate(0, 180, 0);
            }
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            employee.transform.GetComponent<Animator>().SetBool("CharacterHasBeenSeen", false);
            employee.playerSeen = false;
        }
    }
}
