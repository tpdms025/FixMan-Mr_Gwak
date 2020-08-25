using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultWindow : MonoBehaviour
{
    private GameObject bg;
    private TweenPosition vineSprite;
    private GameObject iCON_Victory;
    private GameObject iCON_Fail;

    private UILabel scoreLabel;
    private UILabel timeLabel;
    private UILabel lifeLabel;
    private UILabel comboLabel;


    private void Awake()
    {
        bg = transform.Find("Background").gameObject;
        vineSprite = transform.Find("VineSprite").GetComponent<TweenPosition>();
        iCON_Victory = transform.Find("ICON_Victory").gameObject;
        iCON_Fail = transform.Find("ICON_Fail").gameObject;

        scoreLabel = bg.transform.Find("Score").GetComponentInChildren<UILabel>();
        timeLabel = bg.transform.Find("Time").GetComponentInChildren<UILabel>();
        lifeLabel = bg.transform.Find("Life").GetComponentInChildren<UILabel>();
        comboLabel = bg.transform.Find("Combo").GetComponentInChildren<UILabel>();
    }

    public void OnResult(bool isSuccess, int score, float time, int life, int combo)
    {
        scoreLabel.text = score.ToString();
        timeLabel.text = time.ToString("0");
        lifeLabel.text = life.ToString();
        comboLabel.text = combo.ToString();

        iCON_Victory.SetActive(false);
        iCON_Fail.SetActive(false);


        //Tween
        bg.GetComponent<TweenPosition>().enabled = true;
        vineSprite.enabled = true;
        if (isSuccess)
        {
            iCON_Victory.SetActive(true);
            iCON_Victory.GetComponent<TweenScale>().enabled = true;
        }
        else
        {
            iCON_Fail.SetActive(true);
            iCON_Fail.GetComponent<TweenScale>().enabled = true;
        }

    }
}
