using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusForShader : MonoBehaviour
{
    public PlayerParameters playerVariables;

    private void Start()
    {
        if(playerVariables == null)
        {
            Debug.Log("Check game object - " + gameObject.name + " in script RadiusForShader for public variables");
            gameObject.GetComponent<RadiusForShader>().enabled = false;
        }
    }

    void Update()
    {
        //gets information from shader
        Shader.SetGlobalVector("_Position", transform.position);
        Shader.SetGlobalFloat("_Radius", playerVariables.radius);
    }
}
