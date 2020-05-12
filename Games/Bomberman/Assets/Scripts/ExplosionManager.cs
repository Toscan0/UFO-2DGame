using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ExplosionManager : MonoBehaviour
{
    [SerializeField]
    private int explosionRange = 1;

    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private Tile wallTile;
    [SerializeField]
    private Tile[] destructibleTiles;
    [SerializeField]
    private GameObject explosionPrefab;

    public void Explode(Vector2 worldPos)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);

        CreateExplosation(originCell);

    }

    private bool ExplodeCell(Vector3Int cellPos)
    {
        Tile tile = tilemap.GetTile<Tile>(cellPos);

        if(tile == wallTile)
        {
            return true;
        }
        foreach(var destructibleTile in destructibleTiles)
        {
            if (tile == destructibleTile)
            {
                // destroy tile
                tilemap.SetTile(cellPos, null);
            }
        }
        

        // create an explosion
        Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cellPos);
        var explosion = Instantiate(explosionPrefab, cellCenterPos, Quaternion.identity);
        Destroy(explosion, 0.7f);

        return false;
    }

    private void CreateExplosation(Vector3Int cellPos)
    {
        bool wasBlocked;

        // Where bomb was placed 
        ExplodeCell(cellPos);

        // X axys 
        for (int i = 0; i < explosionRange; i++)
        {
            wasBlocked = ExplodeCell(cellPos + new Vector3Int(i + 1, 0 , 0));
            if (wasBlocked)
            {
                break;
            }
        }
        for (int i = 0; i < explosionRange; i++)
        {
            wasBlocked = ExplodeCell(cellPos - new Vector3Int(i + 1, 0, 0));
            if (wasBlocked)
            {
                break;
            }
        }

        // Y axis
        for (int i = 0; i < explosionRange; i++)
        {
            wasBlocked = ExplodeCell(cellPos + new Vector3Int(0, i + 1, 0));
            if (wasBlocked)
            {
                break;
            }
        }
        for (int i = 0; i < explosionRange; i++)
        {
            wasBlocked = ExplodeCell(cellPos - new Vector3Int(0, i + 1, 0));
            if (wasBlocked)
            {
                break;
            }
        }
    }
}
