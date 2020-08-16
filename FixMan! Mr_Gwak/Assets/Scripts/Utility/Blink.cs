using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public IEnumerator BlinkAnim(UILabel label)
    {
        float time = 0;
        while (true)
        {
            if (time < 1.0f)
            {
                label.color = new Color(label.color.r, label.color.g, label.color.b, time);
            }
            else
            {
                label.color = new Color(label.color.r, label.color.g, label.color.b, 2.0f-time);
                if (time > 2.0f)
                {
                    time = 0;
                }
            }

            time += Time.deltaTime;
            yield return null;
        }
    }
}
