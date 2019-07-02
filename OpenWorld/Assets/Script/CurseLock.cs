using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseLock : MonoBehaviour
{
    void Start()
    {
        //Locks cursor so that it doesn't leave screen and the cursor becomes invisible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
