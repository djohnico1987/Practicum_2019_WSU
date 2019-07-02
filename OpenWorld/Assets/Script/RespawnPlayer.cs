using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    private GameObject player;
    private GameObject respawnPoint;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
    }
    
    void Update()
    {
        if (!player.activeInHierarchy) //when player 'dies' or player game object is disabled, it's placed the game object 'respawn'
        {
            player.transform.position = respawnPoint.transform.position;
            player.transform.rotation = respawnPoint.transform.rotation;
            player.SetActive(true);
        }
    }
}
