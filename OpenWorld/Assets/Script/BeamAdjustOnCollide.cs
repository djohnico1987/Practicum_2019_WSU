using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamAdjustOnCollide : MonoBehaviour
{
    public PlayerParameters playerVariables;
    private LineRenderer self;

    private void Start()
    {
        //error checks for null public variables
        if (playerVariables == null)
        {
            Debug.Log("Check game object - " + gameObject.name + " in script BeamAdjustOnCollide for public variables");
            gameObject.GetComponent<BeamAdjustOnCollide>().enabled = false;
        }
        self = GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, playerVariables.maxDistanceOfLightBeam, playerVariables.hitLayers);

        //changes line length if raycast hits another object
        if (hit.distance < playerVariables.maxDistanceOfLightBeam && hit.distance > 0)
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
