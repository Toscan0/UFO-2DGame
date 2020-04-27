using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(100f, 500f)]
    private float fireRange = 100;
    [SerializeField]
    [Range(0.1f, 1.5f)]
    private float fireRate = 0.3f;
    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;
    /*[SerializeField]
    private Transform firePoint;*/
    [SerializeField]
    private ParticleSystem muzleParticle;
    [SerializeField]
    private AudioClip shotClip;
    [SerializeField]
    private AudioSource audioSource;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun()
    {
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, fireRange))
        {
            var health = hitInfo.collider.GetComponent<Health>();

            if(health != null)
            {
                health.TakeDamage(damage);
            }
        }

        muzleParticle.Play();
        audioSource.clip = shotClip;
        audioSource.Play();
    }
}
