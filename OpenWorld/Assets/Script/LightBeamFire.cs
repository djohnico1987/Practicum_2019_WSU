using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamFire : MonoBehaviour
{
    public GameObject lightBeam; //Should be an empty game object that holds all fx
    
    void Update()
    {
        //turns player weapon on and off
        if (Input.GetButtonDown("Fire1"))
        {
            lightBeam.SetActive(true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            lightBeam.SetActive(false);
        }
    }
}
