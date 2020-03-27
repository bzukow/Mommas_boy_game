using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift_entry : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<Character_controller>().started = true;
            collider.GetComponent<Animator>().SetBool("enter_the_lift", true);
            collider.transform.eulerAngles = new Vector3(
                collider.transform.eulerAngles.x,
                collider.transform.eulerAngles.y + 45,
                collider.transform.eulerAngles.z
            );
            collider.GetComponent<Character_controller>().lift1 = true;
        }
    }
}
