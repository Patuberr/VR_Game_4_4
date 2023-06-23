using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    private bool isFading = false;

    private void Start()
    {
        // Start the fade-in effect
        StartCoroutine(FadeIn());
    }

    public void LoadScene(string sceneName)
    {
        if (!isFading)
            StartCoroutine(FadeOutAndLoadScene(sceneName));
    }

    private IEnumerator FadeIn()
    {
        fadeImage.gameObject.SetActive(true);

        Color initialColor = fadeImage.color;
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float t = elapsedTime / fadeDuration;
            fadeImage.color = Color.Lerp(initialColor, targetColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = targetColor;
        fadeImage.gameObject.SetActive(false);
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        fadeImage.gameObject.SetActive(true);

        Color initialColor = fadeImage.color;
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1f);

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float t = elapsedTime / fadeDuration;
            fadeImage.color = Color.Lerp(initialColor, targetColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = targetColor;

        // Load the next scene
        SceneManager.LoadScene(sceneName);
    }
}
