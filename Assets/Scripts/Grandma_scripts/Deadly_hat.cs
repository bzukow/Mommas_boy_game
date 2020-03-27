using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadly_hat : MonoBehaviour
{
    public float speed = 10f;
    public bool moveUp;
    public Transform parentPos;
    public Vector3 startPos;
    public float count;
    public Transform playerTarget;

    void Start() {
        count = 0;
        moveUp = true;
    }
    public float step;
    // Update is called once per frame
    void Update()
    {
        if (parentPos != null)
        {
            startPos = parentPos.position;
            step = speed * Time.deltaTime;

            if (count >= 1)
            {
                Destroy(gameObject);
            }

            if (!moveUp)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, step);
            }
            else if (moveUp)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, step);
            }
        } else
        {
            Destroy(gameObject);
        }
        
    }

   void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Grandma"))
        {
            count++;
        }
    }
}
