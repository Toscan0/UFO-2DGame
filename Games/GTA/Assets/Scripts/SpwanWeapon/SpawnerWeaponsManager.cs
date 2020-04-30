using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SpawnerWeaponsManager : MonoBehaviour
{
    [SerializeField] private int rotateSpeed = 1;
    [SerializeField] private GameObject ourPistol;
    private AudioSource auidoSource;

    private void Awake()
    {
        auidoSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }


    void OnTriggerEnter(Collider other)
    {
        auidoSource.Play();
        ourPistol.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
