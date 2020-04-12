using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public GameObject impactEffectPrefab;

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
        Debug.Log(hitInfo);

        ITakeDamage damagable = hitInfo.GetComponent<ITakeDamage>();
		if (damagable != null)
		{
            damagable.TakeDamage(damage);
		}

		GameObject impactEffectAux = Instantiate(impactEffectPrefab, transform.position, transform.rotation);
        
		Destroy(gameObject);
        Destroy(impactEffectAux, 1);
    }
	
}
