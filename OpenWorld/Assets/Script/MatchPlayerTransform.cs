using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPlayerTransform : MonoBehaviour
{
    public Transform player;
    private bool message = false;

    private void Update()
    {
        //simply matches player transform as if it a child
        if(transform != player && player != null)
        {
            transform.position = player.position;
            transform.rotation = player.rotation;
        }

        //Keeps error from spamming log. Must have 'player' transform set up to work
        else if(player == null && !message)
        {
            message = true;
            Debug.Log("Public Transform not set for game object - " + gameObject.name + " in script MatchPlayerTransform.");
            return;
        }
    }
}
