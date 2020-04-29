using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A02_MoveChar : MonoBehaviour
{
    [SerializeField]
    private AudioSource leftFoot;
    [SerializeField]
    private AudioSource rightFoot;
    [SerializeField]
    private bool steppingLeft = true;
    [SerializeField]
    private GameObject mainChar;
    [SerializeField]
    private int stepsTaken;

    private void Start()
    {
        StartCoroutine(WalkSequence());
    }

    private void Update()
    {
        mainChar.transform.Translate(0, 0, 0.014f * Time.timeScale);
    }

    IEnumerator WalkSequence()
    {
        yield return new WaitForSeconds(0.4f);
        while(stepsTaken < 13)
        {
            yield return new WaitForSeconds(0.5f);
            if(steppingLeft == true)
            {
                leftFoot.Play();
                steppingLeft = false;
            }
            else
            {
                rightFoot.Play();
                steppingLeft = true;
            }
            stepsTaken += 1;
        }
        mainChar.SetActive(false);
    }
}
