using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
	public float speed;
	
    public float distance;
	public float detectDistance;

    //So that once the enemy needs to stop moving and turn we change movingRight to false
    private bool movingRight = true;
    public Transform groundDetection;
	
	public LineRenderer lineOfSight;
	
	[SerializeField]Transform spawnPoint;

	


    // Use this for initialization
    void Start()
    {
		Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, detectDistance);
		
		if(hitInfo.collider != null)
		{
			Debug.DrawLine(transform.position, hitInfo.point, Color.red);
			lineOfSight.SetPosition(1, hitInfo.point);
			
			if(hitInfo.collider.CompareTag("Player"))
			{
				//Destroy(hitInfo.collider.gameObject);
				hitInfo.transform.position = spawnPoint.position;

				
			}
			
		}
		
		else
		{
			Debug.DrawLine(transform.position, transform.position + transform.right * detectDistance, Color.green);
			lineOfSight.SetPosition(1, transform.position + transform.right * detectDistance);
		}
		    
		lineOfSight.SetPosition(0, transform.position);
		
		
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
