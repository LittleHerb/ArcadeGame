using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool Jump = false;
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
        }
    }

    private void FixedUpdate()
    {
        //Move our Character and move the same amount regardless of the amount of times called
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, Jump);
        Jump = false;
    }
}
