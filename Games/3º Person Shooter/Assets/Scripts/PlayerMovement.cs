using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 100;

    private Vector3 movement;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0, vertical);
    }

    private void FixedUpdate()
    {
        characterController.SimpleMove(movement * moveSpeed * Time.fixedDeltaTime);
    }
}
