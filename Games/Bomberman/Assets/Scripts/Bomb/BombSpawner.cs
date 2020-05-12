using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private GameObject bombPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = tilemap.WorldToCell(worldPos);
            Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cellPos);

            Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
        }
    }
}
