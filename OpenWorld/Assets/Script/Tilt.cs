using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{
    public PlayerParameters playerVariables;
    private float vAxis;

    private bool message = false;

    void Update()
    {
        //prevents error spam
        if (playerVariables == null && !message)
        {
            message = true;
            Debug.Log("Check game object - " + gameObject.name + " in script Tilt for public variables");
        }
        //applies vertical tilt based on yaxis mouse movement
        else
        {
            vAxis += Input.GetAxisRaw("Mouse Y") * playerVariables.tiltCameraSpeed;
            vAxis = Mathf.Clamp(vAxis, playerVariables.minTilt, playerVariables.maxTilt);

            Vector3 copyYZ = transform.rotation.eulerAngles;

            transform.rotation = Quaternion.Euler(-vAxis, copyYZ.y, copyYZ.z);

            transform.position = transform.position;
        }
    }
}
