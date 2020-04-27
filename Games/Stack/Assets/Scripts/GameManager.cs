using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnCubeSpawned = delegate { };

    [SerializeField]
    private CubeSpawner cubeSpawnerX;
    [SerializeField]
    private CubeSpawner cubeSpawnerZ;

    private CubeSpawner currentSpawner;
    private int spawnerIndex;
    private CubeSpawner[] spawners = new CubeSpawner[2];

    private void Awake()
    {
        spawners[0] = cubeSpawnerX;
        spawners[1] = cubeSpawnerZ;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")){

            if(MovingCube.CurrentCube != null)
            {
                MovingCube.CurrentCube.Stop();
            }

            spawnerIndex = spawnerIndex == 0 ? 1 : 0;
            currentSpawner = spawners[spawnerIndex];

            currentSpawner.SpawnCube();
            OnCubeSpawned();
        }
    }
}
