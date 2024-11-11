using System.Collections;
using UnityEngine;

public class SelfDestructPlatform : MonoBehaviour
{
    public string playerTag = "Player"; // Tag for the player GameObject
    public float shakeDuration = 1.0f; // Duration of the shake (1 second)
    public float shakeIntensity = 0.1f; // Intensity of the shake

    private Vector3 originalPosition; // Original position of the platform

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player stepped on the platform
        if (other.CompareTag(playerTag))
        {
            // Start the shaking and self-destruction process
            StartCoroutine(ShakeAndDestroy());
        }
    }

    private IEnumerator ShakeAndDestroy()
    {
        originalPosition = transform.position;
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            // Create a random shake offset
            float offsetX = Random.Range(-shakeIntensity, shakeIntensity);
            float offsetY = Random.Range(-shakeIntensity, shakeIntensity);

            // Apply the shake offset to the platform's position
            transform.position = originalPosition + new Vector3(offsetX, offsetY, 0);

            // Increment elapsed time and wait until the next frame
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Reset the position to the original before destruction
        transform.position = originalPosition;

        // Destroy the platform after the shake duration
        Destroy(gameObject);
    }
}