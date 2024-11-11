using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitTrigger : MonoBehaviour
{
    public string targetTag = "FireBall";  
    // Assign these in the Inspector
    public GameObject platform; // Platform that will rise
    public Vector3 targetPosition; // Final position for the platform
    public float platformSpeed = 2.0f; // Speed at which the platform will rise

    private bool isPlatformRising = false; // Track if the platform should rise

    void Update()
    {
        // Move the platform if it's set to rise
        if (isPlatformRising)
        {
            // Move the platform towards the target position
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, targetPosition, platformSpeed * Time.deltaTime);

            // Stop movement if the platform reaches the target position
            if (platform.transform.position == targetPosition)
            {
                isPlatformRising = false;
            }
        }
    }

    private void OnTriggerFireBallEnter(Collider other)
    {
        // Check if the colliding object has the tag "FireBall"
        if (other.CompareTag(targetTag))
        {
            // Trigger the platform to rise¨
            Debug.Log("Platform is Rising");
            isPlatformRising = true;
        }
    }
}
