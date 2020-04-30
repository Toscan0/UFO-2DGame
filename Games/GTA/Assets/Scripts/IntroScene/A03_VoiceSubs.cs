using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class A03_VoiceSubs : MonoBehaviour
{
    [SerializeField]
    private Text subText;
    [SerializeField]
    private AudioSource voiceLine01;
    [SerializeField]
    private AudioSource voiceLine02;
    [SerializeField]
    private AudioSource voiceLine03;
    [SerializeField]
    private AudioSource voiceLine04;
    [SerializeField]
    private AudioSource loudBang;
    [SerializeField]
    private GameObject fullBlack;
    [SerializeField]
    private GameObject deathObj;
    [SerializeField]
    private GameObject chairScene;
    [SerializeField]
    private AudioSource voiceLine05;
    [SerializeField]
    private GameObject fourCam;
    [SerializeField]
    private GameObject fadeOut;

    private void Start()
    {
        StartCoroutine(IntroSub());
    }

    IEnumerator IntroSub()
    {
        subText.color = new Color(1, 1, 1);
        yield return new WaitForSeconds(8);
        subText.text = "You asked fot this George.";
        voiceLine01.Play();
        subText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        subText.text = "";
        yield return new WaitForSeconds(1);
        subText.text = "Lorenzo, I sweat it wasn't me.";
        voiceLine02.Play();
        yield return new WaitForSeconds(2.1f);
        subText.text = "";
        yield return new WaitForSeconds(0.2f);
        subText.text = "You squeal in horseface, you sleepin' with the fishes.";
        voiceLine03.Play();
        yield return new WaitForSeconds(3f);
        subText.text = "";
        yield return new WaitForSeconds(0.1f);
        subText.text = "Lorenzo! Please!";
        voiceLine04.Play();
        yield return new WaitForSeconds(0.7f);
        subText.text = "";
        yield return new WaitForSeconds(0.3f);
        loudBang.Play();
        fullBlack.SetActive(true);
        deathObj.SetActive(true);
        chairScene.SetActive(false);
        yield return new WaitForSeconds(2f);
        subText.text = "My name is Steve Lorenzo!";
        voiceLine05.Play();
        yield return new WaitForSeconds(2f);
        fullBlack.SetActive(false);
        fourCam.SetActive(true);
        subText.text = "Three years ao Jimmy Horseface tries to have me whacked! Set me up";
        yield return new WaitForSeconds(5f);
        subText.text = "Now it's time for me to return that favour.";
        yield return new WaitForSeconds(3f);
        subText.text = "";
        yield return new WaitForSeconds(3f);
        fadeOut.SetActive(true);

    }

}
