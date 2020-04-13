using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_target_camera : MonoBehaviour
{
    private GameObject player;
    private Character_controller playerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Character_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerScript.facingLeft)
        {
            transform.position = new Vector3(player.transform.position.x + 3f, player.transform.position.y + 4f, player.transform.position.z - 12f);

        }
        else
        {
            transform.position = new Vector3(player.transform.position.x -3f, player.transform.position.y + 4f, player.transform.position.z - 12f);
        }
    }
}
