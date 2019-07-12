using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamAdjustOnCollide : MonoBehaviour
{
    public PlayerParameters playerVariables;
    private bool message = false;
    private LineRenderer self;

    private void Start()
    {
        self = GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {

        //int layermask = 1 << 9;
        //layermask = ~layermask;
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, playerVariables.maxDistanceOfLightBeam, playerVariables.hitLayers);

        //error checks for null public variables
        if (playerVariables == null && !message)
        {
            message = true;
            Debug.Log("Check game object - " + gameObject.name + " in script BeamAdjustOnCollide for public variables");
        }
        //changes line length if raycast hits another object
        else if (hit.distance < playerVariables.maxDistanceOfLightBeam && hit.distance > 0)
        {
            self.SetPosition(1, new Vector3(0f, 0f, hit.distance));
            //transform.localScale = new Vector3( 0f, 0f, playerVariables.maxDistanceOfLightBeam / hit.distance);
        }
        //line stays max length if raycast does not hit another object
        else
        {
            self.SetPosition(1, new Vector3(0f, 0f, playerVariables.maxDistanceOfLightBeam));
            //transform.localScale = new Vector3(0f, 0f, 1f);
        }
    }
}
