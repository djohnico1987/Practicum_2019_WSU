using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Parameters", menuName = "Controller Parameter")]
public class PlayerParameters : ScriptableObject

{
    [Header("Radius of Material Change")]
    [Tooltip("Adjust the value to increase/decrease the radius color/texture change that follows the player")]
    [Range(0, 40f)]
    public float radius = 20f;

    [Header("Movement")] //variables for walking movement and jump

    [Range(0, 20f)]
    public float walkSpeed = 5f;

    [Range(0, 20f)]
    public float sideSpeed = 3f;

    [Range(0, 20f)]
    public float backSpeed = 2f;

    [Range(0, 20f)]
    public float rotateSpeed = 3f;

    public bool canPlayerJump = false;

    [Range(0, 40f)]
    public float jumpHeight = 5f;

    [Header("Movement Modifications")] //stats that may not be needed due to limiting player movement

    public bool canPlayerSprint = false;

    [Range(0, 3f)] 
    public float sprintSpeedMultiplier = 1.5f;

    [Range(0, 10f)]
    [Tooltip("Used for Improved Jump, increase/decrease fall speed for better UX")]
    public float improvedFallSpeed = 3f;

    [Range(0, 10f)]
    [Tooltip("Used for Improved Jump, increase/decrease jump speed for better UX")]
    public float improvedJumpSpeed = 2f;

    [Header("Player Health")]

    public int maxHealth = 0;

    [Tooltip("Decrease or Increase time before player can take damage again")]
    [Range(0, 5f)]
    public float timeInvurnerable = 1f;

    public float timeToRespawn = 1.5f;

    [Tooltip("Color of player when at full health")]
    public Color startHealth;

    [Tooltip("Color of player when at half health")]
    public Color cautionHealth;

    [Tooltip("Color of player when at near death")]
    public Color dangerHealth;

    [Range(0f, 5f)]
    public float levelOfLightIntesity = 2f;

    [Header("Weapon Modificatinos")] //variables to adjust player weapon

    [Range(0, 20f)]
    [Tooltip("Default distance for the max length of light beam")]
    public float maxDistanceOfLightBeam = 15f;

    public LayerMask hitLayers;

    [Header("Camera Follow")] //how the camera follows player speed wise

    [Range(0, 5f)]
    public float tiltCameraSpeed = 1.5f;

    [Range(-90f, 90f)]
    public float minTilt = -45f;

    [Range(-90f, 90f)]
    public float maxTilt = 45f;    
}

