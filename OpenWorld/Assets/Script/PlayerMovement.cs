using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerParameters playerVariables; //gets player scriptable object
    public Rigidbody rb; //used to apply movement
    
    private Vector3 hMove = Vector3.zero; //uses vectors to determine directional movement
    private Vector3 vMove = Vector3.zero;
    private Vector3 movement = Vector3.zero;

    private bool message = false; //for debug.log

    private bool isJumping = false; //It was decided that the player will not able to jump
    private bool isSprinting = false; //It was decided that the player will not able to sprint
    private bool isGrounded = true;

    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal"); //input of WASD
        float vAxis = Input.GetAxisRaw("Vertical");

        hMove = hAxis * transform.right; //used to determine movement of object locally
        vMove = vAxis * transform.forward;

        if (playerVariables != null || rb != null)
        {
            hMove = hMove.normalized * playerVariables.sideSpeed; //applies the amount of speed to move side to side
        }

        //prevents error from spamming log, will help locate opportunity
        if((playerVariables == null || rb == null) && !message)
        {
            message = true;
            Debug.Log("Check game object - " + gameObject.name + " in script Player Movement for public variables");
        }
        else if (vAxis >= 0f) // applies speed based on foward or backwards movement
        {
            vMove = vMove.normalized * playerVariables.walkSpeed;
        }
        else if( vAxis < 0)
        {
            vMove = vMove.normalized * playerVariables.backSpeed;
        }

        //checks to see if player is holding sprint button
        if (Input.GetButtonDown("Sprint") && playerVariables.canPlayerSprint)
        {
            isSprinting = !isSprinting;
        }

        //multiplies the movement by sprint variable
        if (isSprinting) //applies sprint is player choose to have it
        {
            movement = (vMove + hMove) * playerVariables.sprintSpeedMultiplier;//combines horizontal and foward forward movement
        }
        else if (!isSprinting)
        {
            movement = vMove + hMove; //combines horizontal and foward forward movement
        }

        //checks to see if the player is jumping
        if (Input.GetButtonDown("Jump") && playerVariables.canPlayerJump && isJumping == false)
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        if(movement != Vector3.zero) //moves character if there is input
        {
            rb.MovePosition(rb.position + movement * Time.deltaTime);
        }

        // determines if player is grounded using raycast 
        int layermask = 1 << 9;
        layermask = ~layermask;
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, layermask);

        if (isJumping == true && isGrounded)
        {
            rb.velocity = Vector2.up * playerVariables.jumpHeight;
        }

        //if player is grounded, player is able to jump
        if (hit.distance > (transform.localScale.y + 0.1f) || hit.distance == 0)
        {
            isGrounded = false;
            isJumping = true;
        }
        else
        {
            isGrounded = true;
            isJumping = false;
        }
    }
    
}
