using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class PlayerTrigger : MonoBehaviour
{
    public Text totalGoldText;
    private int totalGold;

    private void Start()
    {
        totalGold = GetComponent<PlayerManager>().TotalGold;
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
