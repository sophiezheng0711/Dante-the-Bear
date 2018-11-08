using UnityEngine;
using System.Collections;

public class UIScript: MonoBehaviour
{
    public float offsetx;
    public float offsety;

	void Start()
	{
        Vector2 centerPos = Camera.main.ViewportToWorldPoint(
            new Vector2(0.5f + offsetx, 0.5f + offsety));
        gameObject.transform.position = centerPos;
	}

	void FixedUpdate()
    {
        Vector2 centerPos = Camera.main.ViewportToWorldPoint(
            new Vector2(0.5f + offsetx, 0.5f + offsety));
        gameObject.transform.position = centerPos;
    }
}
