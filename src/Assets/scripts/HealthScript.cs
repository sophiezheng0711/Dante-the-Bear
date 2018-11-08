using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

    public int hp = 1;

    public bool isEnemy = true;

    public GameObject[] buttons;

    public void Damage(int damageCount){
        hp -= damageCount;

        if (hp <= 0){
            
            if (!isEnemy)
            {
                // Only affects the outcome of the level if it's the player
                SpriteRenderer messagebox = GetComponent<PlayerScript>()
                    .messagebox.GetComponent<SpriteRenderer>();
                SpriteRenderer failM = GetComponent<PlayerScript>()
                    .failMessage.GetComponent<SpriteRenderer>();
                messagebox.enabled = true;

                foreach (GameObject temp in buttons){
                    temp.GetComponent<Image>().enabled = true;
                }

                failM.enabled = true;
                Time.timeScale = 0;
            }
            Destroy(gameObject);
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        ShotScript shot = collision.gameObject.GetComponent<ShotScript>();
        if (shot != null){
            if (shot.isEnemyShot != isEnemy) {
                if (GetComponent<PlayerScript>() != null) {
                    // If the player gets attacked, the UI hearts will disappear
                    // one by one. 
                    for (int i = 0; i < shot.damage; i++) {
                        Damage(1);
                        Destroy(GetComponent<PlayerScript>().hearts[hp]);
                    }
                }
                else {
                    Damage(shot.damage);
                }

                Destroy(shot.gameObject);
            }
        }
	}
}
