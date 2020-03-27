using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take_To_End_Platform : MonoBehaviour
{
    private Vector3 startPos;
    public Transform target;
    public float speed = 1f;
    public bool moveUp;

    public Character_controller player;

    void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>();
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        if (moveUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            player.stunned = true;
        }

        if (transform.position.Equals(target.position) && moveUp)
        {
            player.transform.parent.SetParent(null);
            player.stunned = false;
            moveUp = false;
        }
    }
}
