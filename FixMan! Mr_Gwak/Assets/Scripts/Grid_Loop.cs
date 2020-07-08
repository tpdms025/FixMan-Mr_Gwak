using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Loop : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject[] Grids;

    public GameObject A_Zone;       //화면 그리드   
    public GameObject B_Zone;       //화면 위쪽 그리드

    public Vector3 startPos_A;
    public Vector3 startPos_B;

    private bool timeOut = false;
    private void Awake()
    {
        startPos_A = A_Zone.transform.localPosition;
        startPos_B = B_Zone.transform.localPosition;
    }

    private void Start()
    {
        StartCoroutine(Loop());
    }

    //private void FixedUpdate()
    //{
    //    Move();
    //}

    private bool temp = false;

    private IEnumerator Loop()
    {
        while(!timeOut)
        {
        Move();

        yield return null;
        }
    }


    void Move()
    {
        if (B_Zone.transform.localPosition.y <= startPos_A.y)
        {
            Destroy(A_Zone);
            A_Zone = B_Zone;
            GridRandomSetting();
            Debug.Log("dddd" + A_Zone.transform.localPosition.y);
            temp = true;
        }

        if (!temp)
        {
            A_Zone.transform.Translate(Vector3.down * speed * Time.deltaTime);
            B_Zone.transform.Translate(Vector3.down * speed * Time.deltaTime);
            Debug.Log(A_Zone.transform.localPosition.ToString());
            Debug.Log(B_Zone.transform.localPosition.ToString());

        }
    }

    void GridRandomSetting()
    {
        int A = Random.Range(0, Grids.Length);
        B_Zone = NGUITools.AddChild(this.transform.gameObject, Grids[A]);
        B_Zone.transform.localPosition = startPos_B;/*+ new Vector3(0,-20.0f,0);*/
    }
}
