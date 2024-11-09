using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI; // The UI image for the pause menu

    void Start()
    {

    }
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGameFromMainMenu()
    {
        Application.Quit();
        Debug.Log("Game is exiting"); // This line only shows in the editor
    }
  }

