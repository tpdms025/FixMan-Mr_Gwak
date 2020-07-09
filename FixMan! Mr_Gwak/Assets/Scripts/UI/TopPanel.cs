using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPanel : MonoBehaviour
{
    private UISlider timer;
    private UILabel timeLabel;

    private float time = 100.0f;
    private float curTime;

    private void Awake()
    {
        timer = transform.Find("Timer").GetComponent<UISlider>();
        timeLabel = GetComponentInChildren<UILabel>();

        curTime = time;
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while(curTime > 0.0f)
        {
            curTime -= Time.deltaTime;
            timeLabel.text = curTime.ToString("0.00");
            ChangeProgressBar();
            yield return null;
        }

        //game clear!

    }

    public void ChangeProgressBar()
    {
        timer.value -= Mathf.Clamp01(Time.deltaTime / time);
    }
}
