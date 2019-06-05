using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpassableWall : MonoBehaviour
{
    Rigidbody2D rigid;
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        PlayerMovement player = col.GetComponent<PlayerMovement>();
        if (player)
        {
            player.canPhase = false;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        PlayerMovement player = col.GetComponent<PlayerMovement>();
        if (player)
        {
            player.canPhase = true;
        }
    }

}
