using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotationToUpRight : MonoBehaviour
{
    public Rigidbody rb;

    private void Start()
    {
        if (rb == null)
        {
            Debug.Log("Public Rigidbody not set for game object - " + gameObject.name + " in script FixRotationToUpRight");
            gameObject.GetComponent<FixRotationToUpRight>().enabled = false;
        }
    }

    void FixedUpdate()
    {
        rb.ResetInertiaTensor();    
    }
}
