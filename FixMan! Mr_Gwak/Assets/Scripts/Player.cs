using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Property
    private int maxHp = 3;
    private int _health = 3;
    public int health
    {
        get { return _health; }
        set
        {
            if (value < 0)
            {
                _health = 0;
                //gameOver
                //TODO:
            }
            else
            {
            _health = value;

            }
            Debug.Log("hp" + _health);
        }
    }

    private int _combo = 0;
    public int combo
    {
        get { return _combo; }
        set
        {
            _combo = value;
        }
    }
    #endregion

    private GridManager gridManager;

    private void Awake()
    {
        gridManager = GameObject.FindGameObjectWithTag("GridManager").GetComponent<GridManager>();
    }


    public void FillHoney()
    {
        if (gridManager.curNode == null) return;

        if (gridManager.curNode.curFillCount < gridManager.curNode.fillCount)
        {
            gridManager.curNode.curFillCount++;
            
            //combo


            //score up
            if (gridManager.curNode.curFillCount == gridManager.curNode.fillCount)
            {
                GameManager.Inst.currentScore+= gridManager.curNode.score;
            }
        }
        else
        {
            //combo Init
            //TODO:
            Debug.Log("ComboInit");
        }
    }
}
