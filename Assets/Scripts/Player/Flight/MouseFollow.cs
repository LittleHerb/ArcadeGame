using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public float speed = 10f;
    
    // Update is called once per frame
    void Update()
    {
        // 1 - Convert mouse to world
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 2 - Get direction to mouse position (from current position)
        Vector3 direction = mousePos - transform.position;
        // 3 - Convert direction to an angle... Atan2 returns radians, convert to degrees using 'Rad2Deg'
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // 4 - Rotate transform around the Z (forward) using Angle (degrees)
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // 5 - Move towards mouse pos using speed delta
        transform.position = Vector2.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
    }
}
