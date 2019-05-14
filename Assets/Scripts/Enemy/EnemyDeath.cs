using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Transform deathPoint;
    public GameObject player;
    //public GameObject enemy;
    void Start()
    {
        
    }

    void Update()
    {
     

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "player")
        {
            Destroy(col.gameObject);
        }  
   
    }
}
