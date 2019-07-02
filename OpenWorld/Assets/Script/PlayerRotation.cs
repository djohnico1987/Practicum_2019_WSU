using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Vector3 rotateSelf = Vector3.zero;

    public PlayerParameters playerVariables;
    public Rigidbody rb;

    private bool message = false;

    void Update()
    {
        float hAxis = Input.GetAxisRaw("Mouse X");

        //error checks for null public variables
        if ((rb == null || playerVariables == null) && !message)
        {
            message = true;
            Debug.Log("Check game object - " + gameObject.name + " in script PlayerRotation for public variables");
        }
        //gives rotation amount based on mouse horizontal movement
        else
        {
            rotateSelf = new Vector3(0f, hAxis, 0f) * playerVariables.rotateSpeed;
        }
    }

    private void FixedUpdate()
    {
        //applies rotation
        if (rotateSelf != Vector3.zero)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotateSelf));
        }
    }
}
