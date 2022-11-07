using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class Fade : MonoBehaviour
{
    private Image panelImage;

    // Start is called before the first frame update
    void Start()
    {
        panelImage = GetComponent<Image>();
    }

    [YarnCommand("fadein")]
    public void FadeIn()
    {
        StartCoroutine(FadeInPanel());
    }

    private IEnumerator FadeInPanel()
    {
        while (panelImage.color.a > 0)
        {
            float fadeAmount = panelImage.color.a - (3 * Time.deltaTime);

            panelImage.color = new Color(0, 0, 0, fadeAmount);
            yield return null;
        }
    }

    [YarnCommand("fadeout")]
    public void FadeOut()
    {
        StartCoroutine(FadeOutPanel());
        
    }

    private IEnumerator FadeOutPanel()
    {
        while (panelImage.color.a < 1)
        {
            float fadeAmount = panelImage.color.a + (3 * Time.deltaTime);

            panelImage.color = new Color(0, 0, 0, fadeAmount);
            yield return null;
        }
    }
}
