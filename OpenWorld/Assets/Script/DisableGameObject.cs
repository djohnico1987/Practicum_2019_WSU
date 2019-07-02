using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObject : MonoBehaviour
{
    private void LateUpdate()
    {
        gameObject.SetActive(false);
    }
}
