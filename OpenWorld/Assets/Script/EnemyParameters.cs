using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Parameters", menuName = "Enemy Parameter")]
public class EnemyParameters : ScriptableObject
{
    [Header("Health")]

    public int health = 5;

    [Tooltip("How often the enemy can take damage")]
    [Range(0, 3f)]
    public float invurnerableTimer = 0.25f;

    [Header("Player Chase")]

    [Range(0, 50f)]
    public float detectPlayer = 10f;

    [Range(0, 50f)]
    public float losesPlayer = 15f;

    [Range(0, 10f)]
    public float speed = 4f;

    [Tooltip("What the enemy can see through, uncheck if it can't see through a layer.")]
    public LayerMask seesThrough;

    [Header("Attack Details")]
    [Range(0, 50f)]
    public float attackRange = 7f;

    [Range(0, 5f)]
    public float timeBetweenShots = 2f;

    [Range(0, 10f)]
    public float bulletSpeed = 5f;

    [Range(0, 10f)]
    public float bulletLifetime = 5f;

    [Range(0f, 10f)]
    public float bulletTurnSpeed = 2f;
}
