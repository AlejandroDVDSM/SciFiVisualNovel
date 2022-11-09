using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCharacter : MonoBehaviour, IFade
{
    private SpriteRenderer spriteRenderer;
    private float redColor;
    private float greenColor;
    private float blueColor;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        redColor = spriteRenderer.color.r;
        greenColor = spriteRenderer.color.g;
        blueColor = spriteRenderer.color.b;
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCharacter());
    }

    private IEnumerator FadeOutCharacter()
    {
        while (spriteRenderer.color.a > 0)
        {
            float fadeAmount = spriteRenderer.color.a - (1 * Time.deltaTime);

            spriteRenderer.color = new Color(redColor, greenColor, blueColor, fadeAmount);
            yield return null;
        }
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCharacter());
    }

    private IEnumerator FadeInCharacter()
    {
        while (spriteRenderer.color.a < 1)
        {
            float fadeAmount = spriteRenderer.color.a + (1 * Time.deltaTime);

            spriteRenderer.color = new Color(redColor, greenColor, blueColor, fadeAmount);
            yield return null;
        }
    }
}
