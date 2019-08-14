using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchOtherTransform : MonoBehaviour
{
    public Transform otherToMatch;

    private void Start()
    {
        //error checks
        if (otherToMatch == null)
        {
            Debug.Log("Check game object - " + gameObject.name + " in script otherToMatch for public transform");
            gameObject.GetComponent<MatchOtherTransform>().enabled = false;
        }
    }

    void Update()
    {
        transform.rotation = otherToMatch.rotation;
        transform.position = otherToMatch.position;
    }
}
