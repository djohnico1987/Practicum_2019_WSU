using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerParameters playerVariables;

    private float currentHealth;
    private bool invurnerable = false;

    private void OnEnable()
    {
        currentHealth = playerVariables.maxHealth;
        invurnerable = false;
    }

    private void Start()
    {
        currentHealth = playerVariables.maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(invurnerable == false && (other.CompareTag("Enemy") || other.CompareTag("EnemyDamage")))
        {

        }
    }
}
