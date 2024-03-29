﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOtherOnCollision : MonoBehaviour
{
    //disable other object on collide
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().ResetInertiaTensor();
        other.gameObject.SetActive(false);
    }
}
