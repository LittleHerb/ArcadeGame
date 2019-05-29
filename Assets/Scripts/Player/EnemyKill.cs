using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    public GameObject Enemy;
	
    void Start()
    {
        
    }

    void Update()
    {
     

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
        }  
   
    }
}
