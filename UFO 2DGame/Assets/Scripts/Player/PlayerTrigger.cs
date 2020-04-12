using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class PlayerTrigger : PlayerManager
{
    public Text totalGoldText;

    private void Start()
    {
        SetTotalGold();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            totalGold++;

            SetTotalGold();
        }
    }

    private void SetTotalGold()
    {
        totalGoldText.text = "Gold: " + totalGold.ToString();
    }
}
