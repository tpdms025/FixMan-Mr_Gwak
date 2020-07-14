using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int bestScore;
    public int _currentScore;
    public int currentScore
    {
        get { return _currentScore; }
        set
        {
            _currentScore = value;
            if(_currentScore > bestScore)
            {
                bestScore = _currentScore;
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
        }
    }

    static private GameManager instance =null;
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
        else if(Inst != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    public void Save()
    {

    }
    public void Load()
    {
       if( PlayerPrefs.HasKey("BestScore"))
        {

        }

    }

}
