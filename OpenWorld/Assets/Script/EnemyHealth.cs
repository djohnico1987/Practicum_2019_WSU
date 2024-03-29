﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyParameters enemyVariables;

    private int currentHealth;
    private bool invurnerable = false;
    private bool ifVurn = true; //keeps from being restarted on each frame
    
    //sets enemy's health at start
    private void Start()
    {
        if(enemyVariables == null)
        {
            Debug.Log("Check game object - " + gameObject.name + " in script EnemyParameters for public variables");
            gameObject.GetComponent<EnemyHealth>().enabled = false;
        }
        currentHealth = enemyVariables.health;
    }

    private void Update()
    {
        if(currentHealth == 0)
        {
            gameObject.GetComponent<Rigidbody>().ResetInertiaTensor();
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

    private void OnTriggerStay(Collider other)
    {
        if (invurnerable == false && other.CompareTag("PlayerDamage"))
        {
            currentHealth--;
            invurnerable = true;
        }
    }

    //toggles invurnerablity on timer
    IEnumerator Damageable()
    {
        yield return new WaitForSeconds(enemyVariables.invurnerableTimer);
        invurnerable = false;
        ifVurn = true;
    }
}
