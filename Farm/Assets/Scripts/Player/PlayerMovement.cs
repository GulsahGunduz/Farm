using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] FloatingJoystick joystick;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    Animator animator;
    Vector3 moveVector;
    CharacterController characterController;

    float gravity = -9.81f;
    float gravityMultiplier = 3f;
    float gravityVelocity;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        moveVector = Vector3.zero;
        moveVector.x = joystick.Horizontal * moveSpeed * Time.deltaTime;
        moveVector.z = joystick.Vertical * moveSpeed * Time.deltaTime;

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            //Vector3 direction = Vector3.RotateTowards(transform.forward, moveVector, rotateSpeed * Time.deltaTime,0f);
            //transform.rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.LookRotation(moveVector);
            animator.SetBool("run", true);
        }
        else if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            animator.SetBool("run", false);
            animator.SetTrigger("idle");
        }
        ApplyGravity();
        characterController.Move(moveVector);
    }

    private void ApplyGravity()
    {
        if(characterController.isGrounded && gravityVelocity < 0.0f)
        {
            gravityVelocity = -1f;
        }
        else
        {
            gravityVelocity += gravity * gravityMultiplier * Time.deltaTime;
        }
        moveVector.y = gravityVelocity;
    }
}
