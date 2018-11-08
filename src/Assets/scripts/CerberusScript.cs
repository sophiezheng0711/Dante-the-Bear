using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerberusScript : MonoBehaviour {

    /**
     * Cerberus (Level 3 Boss) power description: 
     * Can shoot (to the right)
     **/


    private WeaponScript weapon;

    void Awake()
    {
        // Retrieve the weapon only once
        weapon = GetComponent<WeaponScript>();
    }

    //void Update()
    //{
    //    // Auto-fire
    //    if (weapon != null && weapon.CanAttack)
    //    {
    //        weapon.Attack(true);
    //    }
    //}

    float SavedTime = 0;
    float DelayTime = 1;

    void Update()
    {

        if ((Time.time - SavedTime) > DelayTime)
        {
            SavedTime = Time.time;

            //Anything in here will be called every two seconds        

            if (weapon != null) {
                weapon.Attack(true);
            }
        }

    }
}
