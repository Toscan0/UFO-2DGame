using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    private Block blockPrefab;
    [SerializeField]
    private int numberOfRows = 1;

    private int playWidth = 8;
    private float distanceBetweenBlock = 0.7f;
    private int rowsSpawned;

    private List<Block> blocksSpawned = new List<Block>();

    private void OnEnable()
    {
        for(int i = 0; i < numberOfRows; i++)
        {
            SpawnRowOfBlocks();
        }
    }

    public void SpawnRowOfBlocks()
    {
        foreach(var block in blocksSpawned)
        {
            if(block != null)
            {
                block.transform.position += Vector3.down * distanceBetweenBlock;
            }
        }

        for (int i = 0; i < playWidth; i++)
        {
            if(UnityEngine.Random.Range(0, 100) <= 30) //30% of probabily of spawn a block
            {
                var block = Instantiate(blockPrefab, GetPosition(i), Quaternion.identity);

                int hits = UnityEngine.Random.Range(1, 4) + rowsSpawned;
                block.SetHits(hits);

                blocksSpawned.Add(block);
            }
        }
        rowsSpawned++;
    }

    private Vector3 GetPosition(int i)
    {
        Vector3 position = transform.position;
        position += Vector3.right * i * distanceBetweenBlock;

        return position;
    }
}
