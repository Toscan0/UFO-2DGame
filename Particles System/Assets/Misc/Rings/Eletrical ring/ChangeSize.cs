using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    ParticleSystem ps;
    ParticleSystem.SizeOverLifetimeModule psSizeModuel;

    public float sizeMultiplier = 1;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        psSizeModuel = ps.sizeOverLifetime;
    }

    //just a quick reminder how to change the size over life time
    void Update()
    {
        sizeMultiplier += 0.01f;
        psSizeModuel.sizeMultiplier = sizeMultiplier;
    }
}
