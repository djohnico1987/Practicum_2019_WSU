using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchOtherTransform : MonoBehaviour
{
    public Transform otherToMatch;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = otherToMatch.rotation;
        transform.position = otherToMatch.position;
    }
}
