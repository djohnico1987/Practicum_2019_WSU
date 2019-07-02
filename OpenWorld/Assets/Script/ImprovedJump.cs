using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedJump : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerParameters playerVariables;
    private bool message = false;

    private void LateUpdate()
    {
        //goal is to make the upwards part of a jump more floaty while the fall from the fall faster

        //does not send errors when public variables are not set up.
        if ((rb == null || playerVariables == null) && !message)
        {
            message = true;
            Debug.Log("Check game object - " + gameObject.name + " in script Improved Jump for public variables");
        }
        //Adjust jump fall
        else if (rb.velocity.y < 0f)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (playerVariables.improvedFallSpeed - 1) * Time.deltaTime;
        }
        //adjust jump 'upwards' velocity
        else if (rb.velocity.y > 0f && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (playerVariables.improvedJumpSpeed - 1) * Time.deltaTime;
        }
    }
}
