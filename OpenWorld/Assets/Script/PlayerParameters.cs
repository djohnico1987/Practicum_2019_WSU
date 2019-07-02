using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Parameters", menuName = "Controller Parameter")]
public class PlayerParameters : ScriptableObject

{
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

    public float maxHealth = 0f;

    [Tooltip("Decrease or Increase time before player can take damage again")]
    [Range(0, 5f)]
    public float timeInvurnerable = 1f;

    [Header("Weapon Modificatinos")] //variables to adjust player weapon

    [Range(0, 20f)]
    [Tooltip("Default distance for the max length of light beam")]
    public float maxDistanceOfLightBeam = 15f;

    [Header("Camera Follow")] //how the camera follows player speed wise

    [Range(0, 5f)]
    public float tiltCameraSpeed = 1.5f;

    [Range(-90f, 90f)]
    public float minTilt = -45f;

    [Range(-90f, 90f)]
    public float maxTilt = 45f;    
}

