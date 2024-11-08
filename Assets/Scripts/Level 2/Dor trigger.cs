using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dortrigger : MonoBehaviour
{
    public GameObject objectA; // The object that collides
    public GameObject objectB; // The object to be hit by objectA
    public float moveDistance = 40f; // Distance to move downward
    public float moveSpeed = 5f; // Speed of downward movement

    private bool shouldMove = false; // Whether the object should move
    private Vector3 targetPosition; // Target position to move towards

    void Start()
    {
        // Set the target position to the original position minus moveDistance on the y-axis
        targetPosition = transform.position - new Vector3(0, moveDistance, 0);
    }

    void Update()
    {
        // Check if ObjectA and ObjectB have collided
        if (!shouldMove && CheckCollision(objectA, objectB))
        {
            shouldMove = true; // Start moving downwards
        }

        // If the object should move, gradually move towards the target position
        if (shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Stop moving if the object has reached the target position
            if (transform.position == targetPosition)
            {
                shouldMove = false;
            }
        }
    }

    bool CheckCollision(GameObject objA, GameObject objB)
    {
        Collider colliderA = objA.GetComponent<Collider>();
        Collider colliderB = objB.GetComponent<Collider>();

        return colliderA.bounds.Intersects(colliderB.bounds);
    }
}
