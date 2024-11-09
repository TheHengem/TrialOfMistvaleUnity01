using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFade : MonoBehaviour
{
    public float fadeDuration = 2f; // Duration for a complete fade in and out cycle
    private Image imageComponent;   // Reference to the Image component

    private void Start()
    {
        // Get the Image component attached to this GameObject
        imageComponent = GetComponent<Image>();

        if (imageComponent == null)
        {
            Debug.LogError("Image component is missing from this GameObject.");
            return;
        }

        // Start the fade in and out cycle
        StartCoroutine(FadeInAndOut());
    }

    private IEnumerator FadeInAndOut()
    {
        // Fade In
        yield return StartCoroutine(Fade(0f, 1f, fadeDuration / 2));

        // Fade Out
        yield return StartCoroutine(Fade(1f, 0f, fadeDuration / 2));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;
        Color color = imageComponent.color;

        while (elapsed < duration)
        {
            // Interpolate the alpha value over time
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            imageComponent.color = color;

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the final alpha is set
        color.a = endAlpha;
        imageComponent.color = color;
    }
}