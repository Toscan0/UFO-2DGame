using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCallBacksystem : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(MyRoutine());

        StartCoroutine(MyRoutine( () => {
            Debug.Log("The Routine has finished!");
            Debug.Log("Wow this is cool!");
        }));
    }

    //pass parameter as null, make it optional
    public IEnumerator MyRoutine(Action OnComplete = null)
    {
        yield return new WaitForSeconds(5.0f);

        OnComplete?.Invoke();
    }
}
