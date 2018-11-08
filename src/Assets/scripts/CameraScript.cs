using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject player;

    public int z;

    // basically loads the position of the player and transforms it to the
    // position of the camera, with a depth of z, so that the camera follows
    // the player.
    void Start()
    {
        Vector2 playerPos = player.transform.position;
        Vector3 camPos = new Vector3(playerPos.x, playerPos.y, z);
        gameObject.transform.position = camPos;
    }

    void FixedUpdate()
    {
        Vector2 playerPos = player.transform.position;
        Vector3 camPos = new Vector3(playerPos.x, playerPos.y, z);
        gameObject.transform.position = camPos;
    }
}
