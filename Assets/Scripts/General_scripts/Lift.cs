using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    private Vector3 startPos;
    public Transform target;
    public float speed = 1f;
    private bool moveUp;

    void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent.SetParent(transform);
            moveUp = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        GameObject.FindGameObjectWithTag("Player").transform.parent.SetParent(null);
        moveUp = false;

    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (!moveUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
        }
        else if (moveUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
