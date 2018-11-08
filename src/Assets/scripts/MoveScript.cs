using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;
    // Use this for initialization
    //void Start () {

    //}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("1" + speed);
        //Debug.Log("2" + direction);
        //Debug.Log("3" + rigidbodyComponenet);
        if (rigidbodyComponent != null)
        {
            movement = new Vector2(speed.x * direction.x * Time.deltaTime, rigidbodyComponent.velocity.y + (speed.y * direction.y * Time.deltaTime));
        }
    }

    void FixedUpdate()
    {
		
        if (rigidbodyComponent == null)
        {
            rigidbodyComponent = GetComponent<Rigidbody2D>();
        }
        rigidbodyComponent.velocity = movement;
    }
}
