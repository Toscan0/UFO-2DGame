using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AA_Opening : MonoBehaviour
{
    public GameObject fadeIn;
    public GameObject theText;
    public GameObject initialCamera;
    public GameObject fadeOut;
    public GameObject thePlayer;
    public GameObject killerFake;


    void Start()
    {
        StartCoroutine(OpenBegin());
    }

    IEnumerator OpenBegin()
    {
        yield return new WaitForSeconds(1);
        theText.SetActive(true);
        yield return new WaitForSeconds(5);
        fadeIn.GetComponent<Animator>().enabled = true;
        initialCamera.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(5);
        fadeOut.SetActive(true);
        fadeIn.SetActive(false);
        theText.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        fadeOut.SetActive(false);
        killerFake.SetActive(false);
        thePlayer.SetActive(true);
        initialCamera.SetActive(false);
        yield return new WaitForSeconds(1f);
        fadeIn.SetActive(true);
        fadeIn.GetComponent<Animator>().Play("FadeInAnim");
    }
}
