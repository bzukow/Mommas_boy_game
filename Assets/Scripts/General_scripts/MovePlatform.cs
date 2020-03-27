using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private Vector3 startPos;
    public Transform target;
    public float speed = 1f;
    private bool moveUp;
    void Start()
    {
        startPos = transform.position;
        moveUp = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject.FindGameObjectWithTag("Player").transform.parent.SetParent(null);

    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (transform.position == target.position)
        {
            moveUp = false;
        }
        else if (transform.position == startPos)
        {
            moveUp = true;
        }
        if (moveUp == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
        }
        else if (moveUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}

