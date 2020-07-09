using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int bestScroe;
    public int _currentScore;
    public int currentScore
    {
        get { return _currentScore; }
        set
        {
            _currentScore = value;
            if(_currentScore > bestScroe)
            {
                bestScroe = _currentScore;
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
}
