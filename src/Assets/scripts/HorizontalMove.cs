using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour {

	public Vector2 speed = new Vector2(20, 20);
	public Vector2 direction = new Vector2(-1, 0);
	public bool gravity = true;
	public int distanceX = 100;
	public int distanceY = 0;
	private int countX = 0;
	private int countY = 0;
	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;
	// Use this for initialization

	// Update is called once per frame
	void Update()
	{
        if (rigidbodyComponent != null)
        {
            if (gravity)
            {
                movement = new Vector2(speed.x * direction.x * Time.deltaTime, rigidbodyComponent.velocity.y + (speed.y * direction.y * Time.deltaTime));
            }
            else
            {
                movement = new Vector2(speed.x * direction.x * Time.deltaTime, speed.y * direction.y * Time.deltaTime);
            }
        }
		countX = countX + 1;
		countY = countY + 1;
		if (countX > distanceX) {
			countX = 0;
			direction = new Vector2 (direction.x * -1, direction.y);
		}
		if (countY > distanceY) {
			countY = 0;
			direction = new Vector2 (direction.x, direction.y * -1); 
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
