using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    public float startTime = 120.0f; // Set timer starting time in seconds (120 seconds = 2 minutes)
    public Text countdownText; // UI Text to display the countdown
    private float currentTime; // Track the remaining time

    private void Start()
    {
        currentTime = startTime; // Initialize the timer with the starting time
        UpdateCountdownText();   // Update the UI text at the start
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        // Countdown loop
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // Reduce the timer by the time between frames
            UpdateCountdownText();         // Update the displayed time
            yield return null;             // Wait until the next frame
        }

        // Timer has reached zero
        currentTime = 0;
        UpdateCountdownText();
        OnTimerEnd(); // Execute the action when the timer reaches zero
    }

    private void UpdateCountdownText()
    {
        // Format time as MM:SS and update the UI text
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnTimerEnd()
    {
        // This method is called when the timer reaches zero
        // Customize this method to specify what happens at the end of the countdown
        SceneManager.LoadScene("GameOverLevel3");
    }
}

