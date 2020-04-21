using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    //Actions to delegate void functions
    public Action<int, int> Sum;

    public Action ObjectName;

    // Func to delegate non-void functions
    // Last parameter is the return type of the func
    public Func<int> LengthObjectName;
    public Func<float, float, string> AnotherSum;


    void Start()
    {
        Sum = (a, b) =>
        {
            var total = a + b;
            if (total < 100)
            {
                Debug.Log("Total is less than 100");
            }

            Debug.Log("Total: " + total);
        }; //Dont forget ; in the end

        Sum(5, 2);



        ObjectName = () => Debug.Log("Game Object name: " + gameObject.name);
        ObjectName();



        LengthObjectName = () => gameObject.name.Length;
        int count = LengthObjectName();
        Debug.Log("Game Object Lenght: " +  count);



        AnotherSum = (a, b) =>
        {
            // with  {} is necessary return if is a non-void func
            return (a + b).ToString();
        };
        string res = AnotherSum(0.2f, 0.4f);
        Debug.Log("Sum result: " + res);
    }   
}
