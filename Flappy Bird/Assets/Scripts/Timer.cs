﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    private float startTime;
    private float currentTime = 0;
    private static float maxTime = 0;

    void Start()
    {
        startTime = Time.time;
        SetTimerText();
    }

    void Update()
    {
        currentTime = Time.time - startTime;

        if(currentTime > maxTime)
        {
            maxTime = currentTime;
        }

        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = "Time: " + GetMinutes(currentTime) 
        + ":" + GetSecondsToDisplay(currentTime) + ":" 
        + GetMilliseconds(currentTime) +
        "\nMax Time: " + GetMinutes(maxTime)
        + ":" + GetSecondsToDisplay(maxTime) + ":"
        + GetMilliseconds(maxTime);
    }

    private string GetMinutes(float seconds)
    {
        return ((int) seconds / 60).ToString();
    }

    private string GetSecondsToDisplay(float seconds)
    {
        return (seconds % 60).ToString("f0");
    }

    private string GetMilliseconds(float seconds)
    {
        return ((seconds * 1000) % 1000).ToString("f0");
    }
}
