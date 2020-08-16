using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    private Color currentColor = Color.white;

    public IEnumerator FadeIn(UILabel label, float fadeTime)
    {
        float time = 0;
        while (time < fadeTime)
        {
            currentColor = new Color(label.color.r, label.color.g, label.color.b, time / fadeTime);
            label.color = currentColor;

            time += Time.deltaTime;
        }
        yield return null;
    }

    public IEnumerator FadeIn(float fadeTime)
    {
        float time = 0;
        while (time < fadeTime)
        {
        }
        yield return null;
    }
    public IEnumerator FadeOut(UILabel label, float fadeTime)
    {
        float time = 0;
        while (time < fadeTime)
        {
            currentColor = new Color(label.color.r, label.color.g, label.color.b, 1.0f - time / fadeTime);
            label.color = currentColor;

            time += Time.deltaTime;
        }
        yield return null;
    }

    public void Reset()
    {

    }
}
