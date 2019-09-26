using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAnimation : MonoBehaviour
{
    public int testAnimationNumber = 0;

    void Start()
    {
        gameObject.GetComponent<Animator>().SetInteger("TestAnimation", testAnimationNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
