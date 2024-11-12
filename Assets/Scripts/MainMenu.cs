using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI; // Main menu canvas/UI element
    public GameObject targetMenuUI; // The UI element for the menu to reveal
    public GameObject controlsMenuUI;

    void Start()
    {
        mainMenuUI.SetActive(true);   // Ensure main menu is visible on start
        targetMenuUI.SetActive(false); // Ensure target menu is hidden on start
    }

    void Update()
    {
        // You could add logic here if needed, such as checking for key inputs to switch menus
    }

    public void StartGame()
    {
        SceneManager.LoadScene("IntroCutscene");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGameFromMainMenu()
    {
        Application.Quit();
        Debug.Log("Game is exiting"); // This line only shows in the editor
    }

    // New function to hide current menu and show another menu
    public void SwitchMenuCanvas()
    {
        // Toggle visibility of the menus
        Debug.Log("Switching to ");
        mainMenuUI.SetActive(false);  // Hide the main menu
        targetMenuUI.SetActive(true); // Show the target menu
    }
public void SwitchBackMenuCanvas()
    {
        // Toggle visibility of the menus
        Debug.Log("Switching back to main menu");
        mainMenuUI.SetActive(true);  // Hide the main menu
        targetMenuUI.SetActive(false); // Show the target menu
    }
    public void SwitchToControlsanvas()
    {
        // Toggle visibility of the menus
        controlsMenuUI.SetActive(true);  // Hide the main menu
        mainMenuUI.SetActive(false); // Show the target menu
    }
}