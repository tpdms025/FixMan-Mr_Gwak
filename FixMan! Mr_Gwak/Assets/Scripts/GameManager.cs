using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public UIManager uIManager;

    public int bestScore;
    private int _currentScore;
    public int currentScore
    {
        get { return _currentScore; }
        set
        {
            _currentScore = value;
            if (_currentScore > bestScore)
            {
                bestScore = _currentScore;
                //db저장
                PlayerPrefs.SetInt("BestScore", bestScore);
                //점수 출력
                uIManager.topPanel.ChangeScore(_currentScore);
            }
        }
    }

    static private GameManager instance = null;
    static public GameManager Inst
    {
        get { return instance; }
        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        if (Inst == null)
        {
            Inst = this;
        }
        else if (Inst != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        uIManager = GameObject.Find("UI Root").transform.Find("UI").GetComponent<UIManager>();
    }


    public void Save()
    {

    }
    public void Load()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {

        }

    }

}
