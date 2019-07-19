using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamFire : MonoBehaviour
{
    public GameObject lightBeam; //Should be an empty game object that holds all fx

    private void Start()
    {
        if (lightBeam == null)
        {
            Debug.Log("Public object not set for game object - " + gameObject.name + " in script LightBeamFire");
            gameObject.GetComponent<LightBeamFire>().enabled = false;
        }
    }

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
