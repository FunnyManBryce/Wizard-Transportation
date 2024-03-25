using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float fadeDuration = 2f; 
    private SpriteRenderer spriteRenderer;
    [SerializeField] Color targetColor = new Color(1f, 1f, 1f, 1f);

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartFadeIn();
    }

    private void StartFadeIn()
    {
        Color startColor = spriteRenderer.color;
        Color colorIncrement = (targetColor - startColor) / fadeDuration;
        StartCoroutine(FadeInRoutine(startColor, colorIncrement));
    }

    private System.Collections.IEnumerator FadeInRoutine(Color startColor, Color colorIncrement)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            spriteRenderer.color += colorIncrement * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = targetColor;
    }
}
