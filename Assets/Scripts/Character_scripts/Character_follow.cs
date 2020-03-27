using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_follow : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("WaitForPlayersPosition", 0.3f);
        _cameraOffset = transform.position - PlayerTransform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = PlayerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
    }

    void WaitForPlayersPosition()
    {
        _cameraOffset = transform.position - PlayerTransform.position;

    }
}
