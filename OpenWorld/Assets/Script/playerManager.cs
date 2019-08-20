using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    #region Singleton

    public static playerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    private void Start()
    {
        //error checks
        if (player == null)
        {
            Debug.Log("Check game object - " + gameObject.name + " in script playerManager for public variables");
            gameObject.GetComponent<playerManager>().enabled = false;
        }
    }
}
