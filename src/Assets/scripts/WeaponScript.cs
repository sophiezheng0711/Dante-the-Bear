using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public Transform shotPrefab;

    public float shootingRate = 0.25f;

    private float shootCooldown;

	// Use this for initialization
	void Start () {
        shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (shootCooldown > 0) {
            shootCooldown -= Time.deltaTime;
        }
	}

    public bool CanAttack{
        get{
            return shootCooldown <= 0f;
        }
    }

    public void Attack(bool isEnemy){
        if (CanAttack){
            var shotTransform = Instantiate(shotPrefab) as Transform;

            shotTransform.position = transform.position;

            bool dir_right = true;

            if (gameObject.GetComponent<PlayerScript>() != null) {
                dir_right = gameObject.GetComponent<PlayerScript>().dir_right;
            }
            else {
                if (GetComponent<HorizontalMove>().direction.x > 0) {
                    dir_right = true;
                }
                else {
                    dir_right = false;
                }
            }



            ShotScript shot = shotTransform.gameObject
                                           .GetComponent<ShotScript>();

            if (shot != null){
                shot.isEnemyShot = isEnemy;
            }

            MoveScript move = shotTransform.gameObject
                                           .GetComponent<MoveScript>();
            if (move != null){
                if (dir_right)
                {
                    move.direction = this.transform.right;
                }
                else {
                    move.direction = -this.transform.right;
                }
            }
        }
    }


}
