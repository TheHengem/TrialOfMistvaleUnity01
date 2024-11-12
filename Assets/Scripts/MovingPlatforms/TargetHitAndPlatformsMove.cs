using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitAndPlatformsMove : MonoBehaviour

{
    // The platform to move
    public GameObject platform;

    // The target position for the platform to move to
    public Vector3 targetPosition;

    // The speed of movement
    public float moveSpeed = 5.0f;

    // The tag of the object that triggers the movement
    public string triggerTag = "Activator";

    // Flag to start moving the platform
    private bool shouldMove = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other GameObject has the specified tag
        if (other.CompareTag(triggerTag))
        {
            // Set the flag to true to start moving the platform
            shouldMove = true;
        }
    }

    private void Update()
    {
        // Move the platform if the flag is set and the platform is assigned
        if (shouldMove && platform != null)
        {
            // Smoothly move the platform towards the target position
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Stop moving if the platform has reached the target position
            if (platform.transform.position == targetPosition)
            {
                shouldMove = false;
            }
        }
    }
}
