using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A01_CamSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject firstCam;
    [SerializeField]
    private GameObject secondCam;
    [SerializeField]
    private GameObject ThirdCam;

    private void Start()
    {
        StartCoroutine(CamSitcher()); 
    }

    private IEnumerator CamSitcher()
    {
        yield return new WaitForSeconds(4);
        secondCam.SetActive(true);
        firstCam.SetActive(false);
        yield return new WaitForSeconds(5);
        ThirdCam.SetActive(true);
        secondCam.SetActive(false);
    }
}
