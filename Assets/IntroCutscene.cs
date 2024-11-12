using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ImageSequence : MonoBehaviour
{
    // Array of images to show in sequence
    public Image[] imageSequence;

    // Index to track the current image
    private int currentIndex = 0;

    private void Start()
    {
        // Ensure only the first image is visible at the start
        ShowImageAtIndex(currentIndex);
    }

    private void Update()
    {
        // Detect mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Hide the current image
            HideImageAtIndex(currentIndex);

            // Move to the next image in the sequence
            currentIndex++;

            // Check if we've reached the end of the sequence
            if (currentIndex >= imageSequence.Length)
            {
                // Call the function to go to the next level or execute a final action
                GoToNextLevel();
            }
            else
            {
                // Show the next image if there are still images left in the sequence
                ShowImageAtIndex(currentIndex);
            }
        }
    }

    private void ShowImageAtIndex(int index)
    {
        if (index >= 0 && index < imageSequence.Length)
        {
            imageSequence[index].gameObject.SetActive(true);
        }
    }

    private void HideImageAtIndex(int index)
    {
        if (index >= 0 && index < imageSequence.Length)
        {
            imageSequence[index].gameObject.SetActive(false);
        }
    }

    // Function to execute when the sequence is finished
    private void GoToNextLevel()
    {
        // Placeholder for next level logic; modify this as needed
        SceneManager.LoadScene("Level 1");
        
        // Example: Load the next scene (make sure to add using UnityEngine.SceneManagement)
        // UnityEngine.SceneManagement.SceneManager.LoadScene("NextLevelSceneName");
    }
}
