using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenFade : MonoBehaviour
{
    public float fadeDuration = 1f;

    private RawImage rawImage;
    private bool isFading = false;

    private void Awake()
    {
        rawImage = GetComponent<RawImage>();
    }

    public void StartFade()
    {
        if (!isFading)
        {
            StartCoroutine(FadeScreen());
        }
    }

    private IEnumerator FadeScreen()
    {
        isFading = true;
        rawImage.enabled = true;

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = elapsedTime / fadeDuration;
            rawImage.color = new Color(0f, 0f, 0f, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rawImage.color = Color.black;

        isFading = false;

        // Load the next level
        SceneManager.LoadScene("SecondLevel");
    }
}
