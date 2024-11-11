using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireonObject : MonoBehaviour
{
    public string targetTag = "FireBall";        
    public ParticleSystem hitParticles;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object has the specified tag
        if (other.CompareTag(targetTag))
        {
            // Activate the particle system
            if (hitParticles != null)
            {
                hitParticles.gameObject.SetActive(true);
                hitParticles.Play();
            }

            Debug.Log("let there be fire"); 
           
        }
    }

    
}
