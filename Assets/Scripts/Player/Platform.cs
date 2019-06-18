using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector; // References the PlatformEffector 2D component  
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.S)) // If S key is pressed then platform inverts
        {
            effector.rotationalOffset = 180f;
        }
        else
        {
            Invoke("PlatformReset", 0.1f); // Resets platform after slight delay
        }
        
    }

    public void PlatformReset() // Plaftform is reset
    {
        effector.rotationalOffset = 0f;
    }
}
