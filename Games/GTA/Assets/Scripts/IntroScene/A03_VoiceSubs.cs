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

    private void Start()
    {
        StartCoroutine(IntroSub());
    }

    IEnumerator IntroSub()
    {
        yield return new WaitForSeconds(8);
        subText.text = "You asked fot this George.";
        voiceLine01.Play();
        subText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        subText.text = "";
        yield return new WaitForSeconds(1);
        subText.text = "Lorenzo, I sweat it wasn't me.";
        voiceLine02.Play();
        yield return new WaitForSeconds(1.5f);
        subText.text = "";
    }

}
