using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlash : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    public float FadeInTime = 3f;
    public float FadePause = 1f;
    public float FadeOutTime = 3f;


    void Start()
    {
        StartCoroutine(FadeIn(image, FadeInTime, FadePause));
    }
    
    public IEnumerator FadeIn(Image image, float timetoFade, float FadePause)
    {
        Color startColor = image.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        float timer = 0;
        while (timer < timetoFade)
        {
            timer += Time.deltaTime;
            image.color = Color.Lerp(startColor, endColor, timer / timetoFade);
            yield return null;
        }

        yield return new WaitForSeconds(FadePause);

        StartCoroutine(FadeOut(image, FadeOutTime));
    }

    public IEnumerator FadeOut(Image image, float timetoFade)
    {
        Color startColor = image.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        float timer = 0;
        while (timer < timetoFade)
        {
            timer += Time.deltaTime;
            image.color = Color.Lerp(startColor, endColor, timer / timetoFade);
            yield return null;
        }

        image.color = endColor;

    }
}
