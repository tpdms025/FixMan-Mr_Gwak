using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapLevel { easy, normal, hard }

public class GridManager : MonoBehaviour
{
    private int gridMaxCount = 3;

    public MapLevel mapLevel;

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameObject[] grids;

    public GameObject A_Zone;       //화면 그리드   
    public GameObject B_Zone;       //화면 위쪽 그리드
    private Vector3 startPos_AZone;
    private Vector3 startPos_BZone;

    private GameObject selectLine;
    [SerializeField] private Node _curNode = null;
    public Node curNode
    {
        get { return _curNode; }
        set
        {
            _curNode = value;
            ChangeSelectLine(_curNode);
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

    /// <summary>
    /// 그리드들 이동
    /// </summary>
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

    /// <summary>
    /// B존의 그리드를 랜덤으로 세팅한다.
    /// </summary>
    void GridRandomSetting()
    {
        int A = Random.Range(0, grids.Length);
        B_Zone = NGUITools.AddChild(this.transform.gameObject, grids[A]);
        B_Zone.transform.localPosition = startPos_BZone;/*+ new Vector3(0,-20.0f,0);*/
    }

    /// <summary>
    /// B존의 그리드를 가중치 랜덤으로 설정한다.
    /// </summary>
    void GridWeightedRandom()
    {
        float a = 0;
        float[] percentage;
        if (mapLevel == MapLevel.easy)
        {
            percentage = new float[4] { 5.0f, 10.0f, 15.0f, 70.0f };
        }
        else if(mapLevel == MapLevel.normal)
        {
            percentage = new float[4] { 10.0f, 15.0f, 15.0f, 60.0f };
        }
        else
        {
            percentage = new float[4] { 15.0f, 15.0f, 20.0f, 50.0f };
        }


        int A = Random.Range(0, grids.Length);
        B_Zone = NGUITools.AddChild(this.transform.gameObject, grids[A]);
        B_Zone.transform.localPosition = startPos_BZone;/*+ new Vector3(0,-20.0f,0);*/
    }

    private float Choose(float[] probs)
    {

        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

    /// <summary>
    /// 흰색 라인 위치를 현재노드 위치로 변경한다.
    /// </summary>
    /// <param name="_curNode"> 현재 선택된 노드</param>
    public void ChangeSelectLine(Node _curNode)
    {
        selectLine.transform.SetParent(_curNode.transform);
        selectLine.transform.localPosition = Vector3.zero;
        Debug.Log(_curNode.name);
    }
}
