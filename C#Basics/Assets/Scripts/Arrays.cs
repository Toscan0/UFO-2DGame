using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int itemID;
    public string name;
    public string description;
}

public class Arrays : MonoBehaviour
{
    private int[] array1;
    private int[] array2 = new int[5];
    private int[] array3 = new int[] { 1, 2, 3, 4, 5 };

    [SerializeField]
    private Item[] items;

    private void Start()
    {
        foreach(var item in items)
        {
            Debug.Log(item.itemID);
        }
    }

    private Item[] GetItems()
    {
        return items;
    }

}
