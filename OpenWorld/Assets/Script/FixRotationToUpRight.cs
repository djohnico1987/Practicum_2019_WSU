using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotationToUpRight : MonoBehaviour
{
    public Rigidbody rb;
    private bool message = false;

    void FixedUpdate()
    {
        //Keeps object from fallover on collision, a failsafe from locking rigidbody rotations.
        if (gameObject.activeInHierarchy && rb != null)
        {
            rb.angularVelocity = Vector3.zero;
            rb.centerOfMass = Vector3.zero;
            rb.inertiaTensorRotation = Quaternion.identity;
        }

        //Keeps error from spamming log. Must have rigidbody set up to work
        else if (rb == null && !message)
        {
            message = true;
            Debug.Log("Public Rigidbody not set for game object - " + gameObject.name + " in script FixRotationToUpRight");
            return;
        }
    }
}
