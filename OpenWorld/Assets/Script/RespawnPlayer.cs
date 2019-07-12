using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    private GameObject player;
    private GameObject respawnPoint;

    public PlayerParameters playerVariables;

    private bool isPlayerRespawning = false;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
    }
    
    void Update()
    {
        if (playerVariables == null)
        {
            Debug.Log("Check game object - " + gameObject.name + " in script RespawnPlayer for public variables");
            gameObject.GetComponent<RespawnPlayer>().enabled = false;
        }
        if (!player.activeInHierarchy && !isPlayerRespawning) //when player 'dies' or player game object is disabled, it's placed the game object 'respawn'
        {
            isPlayerRespawning = true;
            StartCoroutine(RespawnTimer());
        }
    }

    IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(playerVariables.timeToRespawn);
        player.transform.position = respawnPoint.transform.position;
        player.transform.rotation = respawnPoint.transform.rotation;
        player.SetActive(true);
        isPlayerRespawning = false;
    }
}
