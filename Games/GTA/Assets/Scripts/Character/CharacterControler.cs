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

    private float horizontalMove;
    private float verticalMove;

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

            transform.Rotate(0, horizontalMove, 0);
            transform.Translate(0, 0, verticalMove);
        }
        else
        {
            animation.Play("Idle");
            isRunning = false;
        }
    }
}
