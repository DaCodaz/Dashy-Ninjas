using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController2D controller;
    public float moveSpeed;
    float hMove;
    bool jump;
    bool crouch;

    private void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal")*moveSpeed;
        if(Input.GetButton("Jump"))
        {
            jump = true;
        }
        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    private void FixedUpdate()
    {
        controller.Move(hMove * Time.fixedDeltaTime,crouch,jump);
        jump = false;
    }
}
