using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    private int gridMaxCount = 3;
    [SerializeField]
    private GameObject[] grids;

    public GameObject A_Zone;       //화면 그리드   
    public GameObject B_Zone;       //화면 위쪽 그리드

    private Vector3 startPos_AZone;
    private Vector3 startPos_BZone;

    private GameObject selectLine;
    [SerializeField]
    private GameObject _curNode;
    public GameObject curNode
    {
        get { return _curNode; }
        set
        {
            _curNode = value;
            Selected();
        }
    }

    private void Awake()
    {
        grids = new GameObject[gridMaxCount];
        for (int i = 0; i < gridMaxCount; ++i)
        {
            grids[i]=Resources.Load("Prefabs/Grids/Grid_"+i) as GameObject;
        }
        startPos_AZone = A_Zone.transform.localPosition;
        startPos_BZone = B_Zone.transform.localPosition;

        selectLine = transform.Find("SelectLine").gameObject;
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (B_Zone.transform.localPosition.y <= startPos_AZone.y)
        {
            Destroy(A_Zone);
            A_Zone = B_Zone;
            GridRandomSetting();
        }
        A_Zone.transform.Translate(Vector3.down * speed * Time.deltaTime);
        B_Zone.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void GridRandomSetting()
    {
        int A = Random.Range(0, grids.Length);
        B_Zone = NGUITools.AddChild(this.transform.gameObject, grids[A]);
        B_Zone.transform.localPosition = startPos_BZone;/*+ new Vector3(0,-20.0f,0);*/
    }

    public void Selected()
    {
        selectLine.transform.SetParent(curNode.transform);
        selectLine.transform.localPosition = Vector3.zero;
        Debug.Log(curNode.name);
    }
}
