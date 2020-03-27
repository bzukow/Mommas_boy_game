using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_while_standing : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    public Transform target;
    public float speed = 1f;
    private bool moveUp;
    private bool collide = false;

    void Start()
    {
        endPos = target.position;
        startPos = transform.position;
        moveUp = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.parent.SetParent(transform);
        collide = true;
        target.position = endPos;
        moveUp = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collide = false;
        collision.gameObject.transform.parent.SetParent(null);
        target.position = transform.position;
        moveUp = false;
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (moveUp == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
        }
        else if (moveUp && collide)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
