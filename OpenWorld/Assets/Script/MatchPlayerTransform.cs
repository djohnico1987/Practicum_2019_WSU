using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPlayerTransform : MonoBehaviour
{
    public Transform player;

    private void Start()
    {
        //Keeps error from spamming log. Must have 'player' transform set up to work
        if (player == null)
        {
            Debug.Log("Public Transform not set for game object - " + gameObject.name + " in script MatchPlayerTransform.");
            gameObject.GetComponent<MatchPlayerTransform>().enabled = false;
        }

    }

    private void Update()
    {
        //simply matches player transform as if it a child
        transform.position = player.position;
        transform.rotation = player.rotation;
    }
}
