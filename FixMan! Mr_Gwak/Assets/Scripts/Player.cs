using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Property
    private Animator animator;
    private BoxCollider col;

    private int maxHp = 3;
    private int _health = 3;
    public int health
    {
        get { return _health; }
        set
        {
            if (value <= 0)
            {
                _health = 0;
                //gameOver
                //TODO:
            }
            else
            {
                _health = value;
            }
            Debug.Log("hp : " + _health);
            GameManager.Inst.uIManager.topPanel.ChangeHp(_health);
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
        animator = GetComponent<Animator>();
        col = GetComponentInChildren<BoxCollider>();
        gridManager = GameObject.FindGameObjectWithTag("GridManager").GetComponent<GridManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeadZone"))
        {
            health--;
        }
        Debug.Log(other.name + "colision");
    }
    public void Teleport(Transform target)
    {
        this.transform.SetParent(target);
        this.transform.localPosition = new Vector3(82.0f, 55.0f, 0.0f);
    }

    public void FillHoney()
    {
        if (gridManager.curNode == null) return;

        //animator.SetBool("IsFill",true);
        animator.SetTrigger("Fill");
        //StartCoroutine(FillAnimation());
        if (gridManager.curNode.curFillCount < gridManager.curNode.fillCount)
        {
            gridManager.curNode.curFillCount++;

            if (gridManager.curNode.curFillCount == gridManager.curNode.fillCount)
            {
                //combo up
                //TODO:
                //score up
                GameManager.Inst.currentScore += gridManager.curNode.score;
            }
        }
        else
        {
            //combo Init
            //TODO:
            Debug.Log("ComboInit");
        }
    }

    private IEnumerator FillAnimation()
    {
        while (true)
        {
            Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Fill"));
            Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);


            AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
            if (!clipInfo[0].clip.name.Contains("Player_Fill"))
            {
                yield return null;
                continue;
            }
            float cliptime = clipInfo[0].clip.length;
            yield return new WaitForSeconds(cliptime / animator.GetCurrentAnimatorStateInfo(0).speed);

            Debug.Log("FillAnim End");
            //animator.SetBool("IsFill", false);

            yield return null;
        }

    }
}
