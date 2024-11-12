using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverLevel3 : MonoBehaviour
{
    // This function is called when another collider enters the trigger collider attached to this game object
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag "Player"
        if (other.CompareTag("Player"))
        {
        SceneManager.LoadScene("GameOverLevel3");
        }
    }
}