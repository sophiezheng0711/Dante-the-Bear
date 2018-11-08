using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour {

	public Vector2 speed = new Vector2(0, 9);
	public Vector2 direction = new Vector2(-1, 0);
	private Vector2 movement;
	private Rigidbody2D rigidbodyComponenet;
	// Use this for initialization
	//void Start () {

	//}

	// Update is called once per frame
	void Update()
	{
		movement = new Vector2 (rigidbodyComponenet.velocity.x, rigidbodyComponenet.velocity.y + speed.y);

	}

	void FixedUpdate()
	{
		if (rigidbodyComponenet == null)
		{
			rigidbodyComponenet = GetComponent<Rigidbody2D>();
		}
		rigidbodyComponenet.velocity = movement;
	}
}
