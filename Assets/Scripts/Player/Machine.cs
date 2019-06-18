using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    {
      Debug.Log("Cutscene");        
    }
}
