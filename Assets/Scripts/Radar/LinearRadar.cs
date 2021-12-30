using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearRadar : MonoBehaviour
{
	[SerializeField] private float velocity = 1f;

    void Update()
    {
		transform.position -= transform.up * velocity * Time.deltaTime;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("FixBlock"))
		{
			Destroy(this.gameObject);
		}
	}
}
