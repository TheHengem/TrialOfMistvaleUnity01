using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructAfterTouch : MonoBehaviour
{
    public string triggerTag = "TriggerObject"; // Tag of the object that triggers the shaking and deletion
    public float shakeDuration = 3.0f; // Duration to shake before destruction
    public float shakeIntensity = 0.1f; // Intensity of the shake

    private bool isShaking = false; // Track if shaking is in progress
    private Vector3 originalPosition; // Store original position for shaking

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the specified tag
        if (other.gameObject.CompareTag(triggerTag) && !isShaking)
        {
            // Start the shaking and self-destruction process
            StartCoroutine(ShakeAndDestroy());
        }
    }

    private IEnumerator ShakeAndDestroy()
    {
        isShaking = true;
        originalPosition = transform.position;

        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            // Random shake offset
            float offsetX = Random.Range(-shakeIntensity, shakeIntensity);
            float offsetY = Random.Range(-shakeIntensity, shakeIntensity);
            float offsetZ = Random.Range(-shakeIntensity, shakeIntensity);

            // Apply the shake offset
            transform.position = originalPosition + new Vector3(offsetX, offsetY, offsetZ);

            // Wait until the next frame
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Reset to the original position before deletion
        transform.position = originalPosition;

        // Destroy the GameObject
        Destroy(gameObject);
    }
}
