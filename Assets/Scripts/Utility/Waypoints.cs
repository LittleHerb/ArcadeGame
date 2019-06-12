using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 2f;

    int waypointIndex = 0;

    public float detectDistance;
    public LineRenderer lineOfSight;
    [SerializeField] Transform spawnPoint;


    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        Move();

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, detectDistance);

        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            lineOfSight.SetPosition(1, hitInfo.point);

            if (hitInfo.collider.CompareTag("Player"))
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

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }

        if (waypointIndex >= 1)
        {
            TurnRight();
        }
        else
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }


    }
    void TurnRight()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

}

