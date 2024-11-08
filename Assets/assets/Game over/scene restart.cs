using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenerestart : MonoBehaviour
{
    // This method can be called by a button to load the specific scene "Level 2"
    public void RestartLevel()
    {
        // Loads the scene named "Level 2"
        SceneManager.LoadScene("Level 2");
    }
}
