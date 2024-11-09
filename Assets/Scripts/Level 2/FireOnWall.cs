using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnWall : MonoBehaviour
{
    public string targetTag = "FireBall";         // Set the tag of the object to trigger the reaction
    public ParticleSystem hitParticles;
    //public GameObject fireEffect; // Assign the particle system in the Inspector
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object has the specified tag
        if (other.CompareTag(targetTag))
        {
            // Activate the particle system
            if (hitParticles != null)
            {
                hitParticles.gameObject.SetActive(true);
               // hitParticles.transform.position = transform.position; // Move particles to collision point
                hitParticles.Play();
            }

            // Start the disappearing coroutine
            StartCoroutine(DisappearAfterDelay());
        }
    }

    private IEnumerator DisappearAfterDelay()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2);

        // Deactivate this object
        hitParticles.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
