using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPanel : MonoBehaviour
{
    private UISlider timer;
    private UILabel timeLabel;
    private UILabel hpLabel;
    private UILabel scoreLabel;

    [SerializeField] private float time = 100.0f;
    [HideInInspector] public float curTime;

    

    private void Awake()
    {
        timer = transform.Find("Timer").GetComponent<UISlider>();
        timeLabel = timer.GetComponentInChildren<UILabel>();
        hpLabel = transform.Find("HP").transform.Find("HpCountLabel").GetComponent<UILabel>();
        scoreLabel = transform.Find("ScoreLabel").GetComponent<UILabel>();

        curTime = time;
    }

    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while(curTime > 0.0f)
        {
            curTime -= Time.deltaTime;
            timeLabel.text = curTime.ToString("0");
            ChangeProgressBar();
            yield return null;
        }

        //game clear!
        //TODO:
        GameManager.Inst.uIManager.OpenResult(true);

    }

    public void ChangeProgressBar()
    {
        timer.value -= Mathf.Clamp01(Time.deltaTime / time);
    }

    /// <summary>
    /// 생명력 변경
    /// </summary>
    /// <param name="hp"></param>
    public void ChangeHp(int hp)
    {
        hpLabel.text = hp.ToString();
    }

    /// <summary>
    /// 점수 변경
    /// </summary>
    /// <returns></returns>
    public void ChangeScore(int score)
    {
        scoreLabel.text = score.ToString();
    }

}
