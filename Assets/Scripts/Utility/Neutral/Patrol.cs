using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;

    //So that once the enemy needs to stop moving and turn we change movingRight to false
    private bool movingRight = true;
    public Transform groundDetection;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //moving the enemy
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        // The Raycast line
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            // if the ray has not collided with anything then the character needs to turn
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;

           
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }
}
