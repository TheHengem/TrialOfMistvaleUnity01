using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCollectible : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 45f; // Speed of rotation in degrees per second

    [Header("Bobbing Settings")]
    public float bobbingHeight = 0.25f; // Maximum height difference for bobbing
    public float bobbingSpeed = 2f;     // Speed of the up-and-down bobbing motion

    private Vector3 startPosition; // Initial position of the object

    void Start()
    {
        // Store the starting position to use as the bobbing midpoint
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate the object around its y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

        // Calculate the new y position using a sine wave for smooth bobbing
        float newY = startPosition.y + Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
