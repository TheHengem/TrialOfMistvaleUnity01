using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatforms : MonoBehaviour
{
    public string playerTag = "Player"; // The tag of the object that triggers the bounce
    public float bounceHeight = 2f;  // Height of the bounce
    public float bounceDuration = 0.5f;  // Duration of the bounce

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the Player tag
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Trigger the bounce effect when the player hits this object
            StartCoroutine(BounceObject());
        }
    }

    private IEnumerator BounceObject()
    {
        Vector3 startPosition = transform.position;  // Get the starting position of the object
        float bounceTimeElapsed = 0f;

        // Perform a smooth, eased bounce up and down for the specified duration
        while (bounceTimeElapsed < bounceDuration)
        {
            // Smooth sine bounce: Apply easing to the sine function for a smoother start and end
            float t = bounceTimeElapsed / bounceDuration; // Normalized time (0 to 1)
            float easedTime = Mathf.Sin(t * Mathf.PI); // Use sine wave for smooth easing
            float bounceOffset = Mathf.Sin(easedTime * Mathf.PI) * bounceHeight;

            // Update the position of the object with the bounce effect
            transform.position = new Vector3(startPosition.x, startPosition.y + bounceOffset, startPosition.z);

            bounceTimeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the object ends back at the final position after bounce
        transform.position = startPosition + new Vector3(0, bounceHeight, 0);
    }
}
