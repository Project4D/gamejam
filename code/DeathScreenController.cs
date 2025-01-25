using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathScreenController : MonoBehaviour 
{
    public float fade_speed = 1f;

    public IEnumerator FadeToBlack()
    {
        Image fadeImage = GetComponent<Image>();
        if (fadeImage == null)
        {
            Debug.LogError("Image component not found on DeathScreenController!");
            yield break;
        }

        Color color = fadeImage.color;

        while (color.a < 1f)
        {
            color.a = Mathf.Clamp01(color.a + fade_speed * Time.deltaTime);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;
    }
}