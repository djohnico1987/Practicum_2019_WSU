using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerParameters playerVariables;

    private int currentHealth;
    private bool invurnerable = false;
    private bool ifVurn = true; //keeps from being restarted on each frame

    private Material mat; //used for changing colors
    
    //resets player's health to full health on respawn
    private void OnEnable()
    {
        currentHealth = playerVariables.maxHealth;
        invurnerable = true; //enables a delay to player becoming vurnerable on respawn
    }

    //sets player's health at start
    private void Start()
    {
        currentHealth = playerVariables.maxHealth;
        mat = GetComponent<Renderer>().material;
    }

    //sets player color based on life
    private void Update()
    {
        if(playerVariables == null)
        {
            Debug.Log("Check game object - " + gameObject.name + " in script PlayerHealth for public variables");
            gameObject.GetComponent<PlayerHealth>().enabled = false;
        }

        if (currentHealth == playerVariables.maxHealth)
        {
            mat.SetColor("_EmissionColor", playerVariables.startHealth * Mathf.Pow(2f, playerVariables.levelOfLightIntesity));
        }
        else if (currentHealth == 1)
        {
            mat.SetColor("_EmissionColor", playerVariables.dangerHealth * Mathf.Pow(2f, (playerVariables.levelOfLightIntesity/3)));
        }
        else
        {
            mat.SetColor("_EmissionColor", playerVariables.cautionHealth * Mathf.Pow(2f, (playerVariables.levelOfLightIntesity / 2)));
        }

        if (currentHealth == 0)
        {
            gameObject.SetActive(false);
        }
    }

    //works to toggle invurnerable state
    private void LateUpdate()
    {
        if (invurnerable && ifVurn)
        {
            ifVurn = false;
            StartCoroutine(Damageable());
        }
    }

    //damages player if hit by an enemy
    private void OnTriggerEnter(Collider other)
    {
        if(invurnerable == false && (other.CompareTag("Enemy") || other.CompareTag("EnemyDamage")))
        {
            currentHealth--;
            invurnerable = true;
        }

        if(other.CompareTag("HealthPickUp") && (currentHealth < playerVariables.maxHealth))
        {
            currentHealth++;
            other.gameObject.SetActive(false);
        }
    }

    //toggles invurnerablity on timer
    IEnumerator Damageable()
    {
        yield return new WaitForSeconds(playerVariables.timeInvurnerable);
        invurnerable = false;
        ifVurn = true;
    }
}
