using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCanvas : MonoBehaviour
{
    public float displayDuration = 2f; // Duration for which the canvas is visible (in seconds)

    private void Start()
    {
        // Start the coroutine to hide the canvas after the specified duration
        StartCoroutine(HideCanvasAfterDelay());
    }

    private IEnumerator HideCanvasAfterDelay()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(displayDuration);
        
        // Hide the canvas
        gameObject.SetActive(false);
    }
}
