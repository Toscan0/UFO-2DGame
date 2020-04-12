using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    // Prefab
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
        ITakeDamage damagable = hitInfo.GetComponent<ITakeDamage>();
		if (damagable != null)
		{
            //Debug.Log(hitInfo.name);

            damagable.TakeDamage(damage);
		}

		GameObject impactEffectAux = Instantiate(impactEffect, transform.position, transform.rotation);
        
		Destroy(gameObject);
        Destroy(impactEffectAux, 1);
    }
	
}
