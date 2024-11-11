using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Set these points in the Inspector or directly in code
    public Transform pointA;     // Starting point of the platform
    public Transform pointB;     // Ending point of the platform
    public float speed = 2.0f;   // Speed of the platform movement

    private Vector3 targetPosition;  // The current target position

    void Start()
    {
        // Set initial target position to pointB
        targetPosition = pointB.position;
    }

    void Update()
    {
        // Move the platform towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the platform has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            // Switch target between pointA and pointB
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }
}