using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;

    public void Explode(Vector2 worldPos)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);


    }

   private void ExplodeCell(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);

    }
}
