using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemyPatrol : MonoBehaviour
{
   // public float distance;
    public float timer, maxTime;
    public float detectDistance;

    public LineRenderer lineOfSight;
    public bool lookingRight = true;
    [SerializeField] Transform spawnPoint;


    void Start()
    {
        Physics2D.queriesStartInColliders = false;

    }

    void Update()
    {
        TurnTimer();
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
    }

    public void TurnTimer()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            lookingRight = !lookingRight;
            timer = 0;
        }

        if(lookingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
    }

}
