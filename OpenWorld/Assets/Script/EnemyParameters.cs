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
}
