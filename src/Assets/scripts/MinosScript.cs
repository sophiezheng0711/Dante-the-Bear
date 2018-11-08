using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    private HorizontalMove hm;
    private int direction;
    private Animator ani;

	// Use this for initialization
	void Start () {
        hm = gameObject.GetComponent<HorizontalMove>();
        ani = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (hm.direction.x > 0){
            // going right
            direction = 1;
        }
        else {
            // going left
            direction = -1;
        }
        Attac();
	}

    // Attack form of Minos, can shoot, but is also vulnerable to the player
    void Attac() {
        // TODO animation, weaponscript, etc.
        if (direction == 1){
            ani.SetBool("left", false);
            ani.SetBool("protec", false);
        }
        else if (direction == -1) {
            ani.SetBool("left", true);
            ani.SetBool("protec", false);
        }
    }

    // Protec form of Minos, cannot attack, but cannot be attacked either
    void Protec() {
        // TODO animation, stop movement, nullify attacks from player
        if (direction == 1)
        {
            ani.SetBool("left", false);
            ani.SetBool("protec", true);
        }
        else if (direction == -1)
        {
            ani.SetBool("left", true);
            ani.SetBool("protec", true);
        }
    }
}
