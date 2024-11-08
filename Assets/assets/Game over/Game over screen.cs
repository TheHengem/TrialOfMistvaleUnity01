using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameoverscreen : MonoBehaviour
{
    public string targetTag = "Player";         
    public GameObject gameOver;
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag(targetTag))
        {
            
            if (gameOver != null)
            {
                gameOver.gameObject.SetActive(true);
               
            }

            
            
        }
    }

     
}
