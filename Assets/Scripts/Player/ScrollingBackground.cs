using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float backgroundSize;
    public float parallaxSpeedX;
    public float parallaxSpeedY;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 30;
    private int leftIndex;
    private int rightIndex; 
    private float lastCameraX;
    private float lastCameraY;

    private void Start()
    {      
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            layers[i] = transform.GetChild(i);

        leftIndex = 0;
        rightIndex = layers.Length-1;
    }

    private void Update()
    {
        float deltaX = cameraTransform.position.x - lastCameraX;
        transform.position += Vector3.right * (deltaX * parallaxSpeedX);
        lastCameraX = cameraTransform.position.x;

        float deltaY = cameraTransform.position.y - lastCameraY;
        transform.position += Vector3.up * (deltaY * parallaxSpeedY);
        lastCameraY = cameraTransform.position.y;

        // if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
        // ScrollLeft();

        // if (cameraTransform.position.x < (layers[rightIndex].transform.position.x - viewZone))
        // ScrollRight();
    }

    /*private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex --;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }
    */
}
