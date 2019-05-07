using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public float distance = 2.0f;
    public float throwForce;
    public bool grabbed;
    public Transform holdPoint;
    RaycastHit2D hit;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!grabbed)
            {
                //Physics2D.RaycastsStartInColliders = false;

                //Grab
                hit = Physics2D.Raycast(transform.position,Vector2.right * transform.localScale.x,distance);

                if(hit.collider!=null)
                {
                    grabbed = true;
                }
            }

            else
            {
                //Throw
                grabbed = false;

                if(hit.collider.gameObject.GetComponent<Rigidbody2D>()!=null)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x,1) * throwForce;
                }
            }
        }

        if(grabbed)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;

        }
        

    }

    void OnDrawGizmos ()
    {
        Gizmos.DrawLine(transform.position,transform.position + Vector3.right * transform.localScale.x * distance);
    }
}
