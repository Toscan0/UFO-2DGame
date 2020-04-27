using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreText : MonoBehaviour
{
    private int score;
    private static int maxScore;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        GameManager.OnCubeSpawned += UpdateScore;
    }

    private void UpdateScore()
    {
        score++;

        if( score > maxScore)
        {
            maxScore = score;
        }

        text.text = "Score: " + score + "\n MaxScore: " + maxScore;
    }

    private void OnDestroy()
    {
        GameManager.OnCubeSpawned -= UpdateScore;
    }
}
