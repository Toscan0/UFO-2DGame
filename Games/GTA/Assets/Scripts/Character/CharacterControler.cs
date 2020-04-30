using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animation))]
public class CharacterControler : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 150;
    [SerializeField]
    private float rootSpeed = 8;
    [SerializeField]
    private bool isRunning;

    [SerializeField]
    private bool isStepping;
    [SerializeField]
    private AudioSource footStep1;
    [SerializeField]
    private AudioSource footStep2;

    private float horizontalMove;
    private float verticalMove;
    private int stepNum;

    private new Animation animation;

    private void Awake()
    {
        animation = GetComponent<Animation>();
    }

    void Update()
    {

        

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            animation.Play("Run");
            horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
            verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * rootSpeed;
            isRunning = true;
            if(isStepping == false)
            {
                StartCoroutine(RunSound());
            }
            transform.Rotate(0, horizontalMove, 0);
            transform.Translate(0, 0, verticalMove);
        }
        else
        {
            if (Input.GetButton("Fire1"))
            {
                animation.Play("PistolAim");
            }
            else
            {
                animation.Play("Idle");
                isRunning = false;
            }
            
        }
    }

    private IEnumerator RunSound()
    {
        if(isRunning == true && isStepping == false)
        {
            isStepping = true;
            stepNum = UnityEngine.Random.Range(1, 3);
            if(stepNum == 1)
            {
                footStep1.Play();
            }
            if (stepNum == 2)
            {
                footStep2.Play();
            }
        }
        yield return new WaitForSeconds(0.4f);
        isStepping = false;
    }
}
