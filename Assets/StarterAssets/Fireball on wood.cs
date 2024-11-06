using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballonwood : MonoBehaviour
{
    public string targetTag = "Fireball";         // Set the tag of the object to trigger the reaction
    public ParticleSystem hitParticles;         // Assign the particle system in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object has the specified tag
        if (other.CompareTag(targetTag))
        {
            // Activate the particle system
            if (hitParticles != null)
            {
                hitParticles.transform.position = transform.position; // Move particles to collision point
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
        gameObject.SetActive(false);
    }
}
