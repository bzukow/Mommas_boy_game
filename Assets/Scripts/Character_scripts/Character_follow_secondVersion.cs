using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_follow_secondVersion : MonoBehaviour
{
    // Start is called before the first frame update

    /*public float smoothSpeed = 10.1f;
    public Vector3 offset;
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + new Vector3(0,0,-5) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }*/
    public GameObject objectToFollow;

    public float speed = 2.0f;

    void FixedUpdate()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);
        position.z = Mathf.Lerp(this.transform.position.z, objectToFollow.transform.position.z, interpolation);
        this.transform.position = position;
    }
}
