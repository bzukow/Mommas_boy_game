using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma_top_collider_controller : MonoBehaviour
{
    public Grandma_controller gc;

    void Update()
    {
        transform.position = new Vector3(gc.transform.position.x, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            gc.touchedTheTop = true;
        }
    }
}
