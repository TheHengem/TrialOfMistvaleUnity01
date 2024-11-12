using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMoveDown : MonoBehaviour
{
    // Assign the GameObject you want to move down in the Inspector
    public GameObject objectToMoveDown;

    // Delay before the object starts moving down (in seconds)
    public float moveDelay = 1.0f;

    // Speed at which the object will move downward
    public float moveSpeed = 2.0f;

    // Flag to control the downward movement
    private bool shouldMoveDown = false;

    private void Start()
    {
        if (objectToMoveDown == null)
        {
            Debug.LogWarning("Object to move down is not assigned.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Start the coroutine to delay the movement
            StartCoroutine(StartMovingDownAfterDelay());
        }
    }

    private IEnumerator StartMovingDownAfterDelay()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(moveDelay);

        // Set flag to start moving down
        shouldMoveDown = true;
    }

    private void Update()
    {
        // If the movement should start, move the object downward
        if (shouldMoveDown && objectToMoveDown != null)
        {
            // Move the object down by modifying its position
            objectToMoveDown.transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
    }
}