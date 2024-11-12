using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public GameObject endMenuUI; // Main menu canvas/UI element
    public GameObject creditsMenuUI; // The UI element for the menu to reveal

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ToCredits()
    {
        endMenuUI.SetActive(false);
        creditsMenuUI.SetActive(true);
    }
    public void BacktoEndMenu()
    {
        endMenuUI.SetActive(true);
        creditsMenuUI.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
}
