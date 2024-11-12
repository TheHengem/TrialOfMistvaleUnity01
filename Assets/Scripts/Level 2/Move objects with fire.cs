using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveobjectswithfire : MonoBehaviour
{
    public string targetTag = "FireBall";
    public ParticleSystem hitParticles;
    public GameObject[] objectsToMove; // Array to store multiple objects to move
    public float delayBetweenMoves = 0.5f; // Delay between moving each object in seconds
    public float moveDuration = 2f; // Time in seconds to move the object upward
    public float moveHeight = 40f; // Height to move the object upward (editable in Inspector)
    public float bounceHeight = 2f; // Height of the bounce after the move
    public float bounceDuration = 0.5f; // Duration of the bounce
    public float backAndForthDistance = 5f; // Distance to move back and forth
    public float backAndForthDuration = 1f; // Duration of each back-and-forth cycle
    public float backAndForthSpeed = 1f; // Speed multiplier for back-and-forth movement
    public Vector3 backAndForthDirection = Vector3.right; // Direction to move back and forth

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object has the specified tag
        if (other.CompareTag(targetTag))
        {
            // Activate the particle system
            if (hitParticles != null)
            {
                hitParticles.gameObject.SetActive(true);
                hitParticles.Play();
            }

            Debug.Log("Let there be fire");

            // Start the Coroutine to move the objects
            StartCoroutine(MoveObjectsWithDelay());
        }
    }

    private IEnumerator MoveObjectsWithDelay()
    {
        foreach (GameObject obj in objectsToMove)
        {
            if (obj != null)
            {
                // Start moving the object
                StartCoroutine(MoveObjectUpwards(obj));
            }

            // Wait for the specified delay before moving the next object
            yield return new WaitForSeconds(delayBetweenMoves);
        }
    }

    private IEnumerator MoveObjectUpwards(GameObject obj)
    {
        Vector3 startPosition = obj.transform.position;
        Vector3 targetPosition = startPosition + new Vector3(0, moveHeight, 0); // Move to specified height
        float timeElapsed = 0f;

        // Move the object slowly upwards
        while (timeElapsed < moveDuration)
        {
            obj.transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / moveDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        obj.transform.position = targetPosition; // Ensure the object ends at the target position

        // After moving, make the object bounce a little
        StartCoroutine(BounceObject(obj));
    }

    private IEnumerator BounceObject(GameObject obj)
    {
        Vector3 startPosition = obj.transform.position;
        float bounceTimeElapsed = 0f;

        // Perform a smooth, eased bounce up and down for the specified duration
        while (bounceTimeElapsed < bounceDuration)
        {
            // Smooth sine bounce: Apply easing to the sine function for a smoother start and end
            float t = bounceTimeElapsed / bounceDuration; // Normalized time (0 to 1)
            float easedTime = Mathf.Sin(t * Mathf.PI); // Use sine wave for smooth easing
            float bounceOffset = Mathf.Sin(easedTime * Mathf.PI) * bounceHeight;

            obj.transform.position = new Vector3(startPosition.x, startPosition.y + bounceOffset, startPosition.z);

            bounceTimeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the object ends back at the final position after bounce
        obj.transform.position = startPosition + new Vector3(0, bounceHeight, 0);

        // Start the back-and-forth movement after the bounce
        StartCoroutine(MoveBackAndForth(obj));
    }

    private IEnumerator MoveBackAndForth(GameObject obj)
    {
        Vector3 startPosition = obj.transform.position;
        Vector3 direction = backAndForthDirection.normalized; // Normalize to ensure direction-only influence
        Vector3 leftPosition = startPosition + direction * (-backAndForthDistance / 2);
        Vector3 rightPosition = startPosition + direction * (backAndForthDistance / 2);

        while (true) // Repeat indefinitely
        {
            // Move to the right
            float timeElapsed = 0f;
            while (timeElapsed < backAndForthDuration / backAndForthSpeed)
            {
                obj.transform.position = Vector3.Lerp(leftPosition, rightPosition, timeElapsed / (backAndForthDuration / backAndForthSpeed));
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            // Move to the left
            timeElapsed = 0f;
            while (timeElapsed < backAndForthDuration / backAndForthSpeed)
            {
                obj.transform.position = Vector3.Lerp(rightPosition, leftPosition, timeElapsed / (backAndForthDuration / backAndForthSpeed));
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}
