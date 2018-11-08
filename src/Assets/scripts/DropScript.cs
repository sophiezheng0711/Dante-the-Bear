using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScript : MonoBehaviour {

    public Transform bookPrefab;

    public bool dropped = false;

    private Transform bookTrans;

    public void Drop() {
        var temp = Instantiate(bookPrefab) as Transform;

        temp.position = transform.position;

        Physics2D.IgnoreCollision(temp.GetComponent<Collider2D>(),
                                  GetComponent<Collider2D>());

        if (bookTrans != null)
        {
            Destroy(bookTrans.gameObject);
        }

        bookTrans = temp;
    }
}
