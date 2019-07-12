using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusForShader : MonoBehaviour
{
    public PlayerParameters playerVariables;
    
    void Update()
    {
        //gets information from shader
        Shader.SetGlobalVector("_Position", transform.position);
        Shader.SetGlobalFloat("_Radius", playerVariables.radius);
    }
}
