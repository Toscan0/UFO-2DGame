using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    
    public GameObject impactEffect;

    [SerializeField]
	private float speed = 20f;
    [SerializeField]
    private int damage = 40;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();

		rb2d.velocity = transform.up * speed;
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		/*Enemy enemy = hitInfo.GetComponent<Enemy>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}*/

		//Instantiate(impactEffect, transform.position, transform.rotation);

		//Destroy(gameObject);
	}
	
}
