using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {

    public GameObject[] ignored_objects;

	// Use this for initialization
	void Start () {
        foreach (GameObject temp in ignored_objects)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(),
                                      temp.GetComponent<Collider2D>());
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        FireScript fire = collision.gameObject.GetComponent<FireScript>();
        if (fire != null)
        {
            Destroy(fire.gameObject);
        }
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        BreakableScript breakable = collision.gameObject
                                             .GetComponent<BreakableScript>();
        if (breakable != null)
        {
            Destroy(breakable.gameObject);
        }
	}
}
