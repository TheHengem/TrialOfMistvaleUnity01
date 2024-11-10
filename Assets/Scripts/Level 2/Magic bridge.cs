using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magicbridge : MonoBehaviour
{
    public string triggerTag; // The tag of the object this object will collide with
    public string targetTag; // The tag of this object
    public GameObject[] objectsToMove; // Array of objects to move
    public float moveDistance = 40f; // Distance to move the objects
    public float delayBetweenMoves = 0.5f; // Delay between each object's movement
    public float moveDuration = 2f; // Duration over which each object moves (increase to slow down movement)

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag(triggerTag) && gameObject.CompareTag(targetTag))
        {
            StartCoroutine(MoveObjectsUpward());
        }
    }

    private IEnumerator MoveObjectsUpward()
    {
        foreach (GameObject obj in objectsToMove)
        {
            Vector3 startPosition = obj.transform.position;
            Vector3 targetPosition = startPosition + Vector3.up * moveDistance;

            float elapsedTime = 0;
            while (elapsedTime < moveDuration)
            {
                obj.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            obj.transform.position = targetPosition; // Ensure the final position is set precisely

            yield return new WaitForSeconds(delayBetweenMoves); // Wait before moving the next object
        }
    }
}
