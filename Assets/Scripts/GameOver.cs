using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI; // The UI image for the pause menu

    public void RetryLevel()
    {
        Time.timeScale = 1f; // Unfreeze time before reloading the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGameFromMainMenu()
    {
        Debug.Log("Game is exiting 2");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f; // Unfreeze time before quitting
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Game is exiting 2");
    }
  }

// pauseMenuUI.SetActive(true);
