using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // The UI panel for the pause menu
    public bool isPaused = false;  // Track if the game is currently paused


    void Start()
    {
       pauseMenuUI.SetActive(false); 
    }
    void Update()
    {
        MouseRevealer();
        // Check for the Escape key to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);      // Hide pause menu UI
        Time.timeScale = 1f;               // Unfreeze game time
        isPaused = false;
    }

    // Pause the game
    void Pause()
    {
        pauseMenuUI.SetActive(true);       // Show pause menu UI
        Time.timeScale = 0f;               // Freeze game time
        isPaused = true;
    }

    // Restart the current level

    public void MouseRevealer()
    {
        if(isPaused)
        {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        }
        else
        {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Unfreeze time before reloading the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Quit the game (only works in a built application)
    public void QuitToMainMenu()
    {
        Debug.Log("Game is exiting 2");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f; // Unfreeze time before quitting
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Game is exiting 2");
    }
}
