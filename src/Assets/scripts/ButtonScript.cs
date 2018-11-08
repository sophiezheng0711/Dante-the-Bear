using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    Animator ani;
    GameObject object_controlled;
    Animator gateAni;
    Collider2D gateCol;
    public LayerMask contactLayer;
    GameObject water;

	// Use this for initialization
	void Start () {
        object_controlled = gameObject.transform.GetChild(0).gameObject;
        if (object_controlled.tag.Equals("gate"))
        {
            ani = GetComponent<Animator>();
            ani.enabled = true;
            gateAni = object_controlled.GetComponent<Animator>();
            gateCol = object_controlled.GetComponent<Collider2D>();
            gateCol.enabled = true;
        }
        else if (object_controlled.tag.Equals("pipe")){
            water = object_controlled.transform.GetChild(0).gameObject;
            ani = GetComponent<Animator>();
            ani.enabled = true;
            gateAni = object_controlled.GetComponent<Animator>();
            gateCol = water.GetComponent<Collider2D>();
            gateCol.enabled = false;
        }
	}

	// Update is called once per frame
	void Update () {
        if (object_controlled.tag.Equals("gate"))
        {
            if (isPressed())
            {
                ani.SetBool("Pressed", true);
                gateAni.SetBool("Pressed", true);
                gateCol.enabled = false;
            }
            else
            {
                ani.SetBool("Pressed", false);
                gateAni.SetBool("Pressed", false);
                gateCol.enabled = true;
            }
        }
        else if (object_controlled.tag.Equals("pipe")) {
            if (isPressed())
            {
                ani.SetBool("Pressed", true);
                gateAni.SetBool("Pressed", true);
                gateCol.enabled = true;
            }
            else
            {
                ani.SetBool("Pressed", false);
                gateAni.SetBool("Pressed", false);
                gateCol.enabled = false;
            }
        }
	}

    bool isPressed() {
        // TODO if anyone can make this method more sensitive that would be
        // awesome
        Vector2 position = transform.position;
        Vector2 direction = Vector2.up;
        float distance = 1.0f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, 
                                             contactLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(position, Vector2.right, 0.5f,
                                             contactLayer);
        RaycastHit2D hit3 = Physics2D.Raycast(position, Vector2.left, 0.5f,
                                             contactLayer);
        if (hit.collider != null || hit2.collider != null 
            || hit3.collider != null)
        {
            return true;
        }
        return false;
    }

}
