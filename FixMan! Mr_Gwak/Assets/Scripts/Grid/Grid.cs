using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject hexPrefab;

    public int gridXCount = 11;
    public int gridYCount = 11;

    public float hexWidth = 0.5f;
    public float hexHeight = 0.5f;
    public float gap = 0;

    private Vector3 startPos;

    [Header("Node Information")]
    [Tooltip("0:None\n1:Level4\n2:Level3\n3:Level2\n4:Level1")]
    public string nodesTypeString;
    [SerializeField] private NodeType[] nodesType;


    public bool Update = true;



    private void AddGap()
    {
        hexWidth += hexWidth * gap;
        hexHeight += hexHeight * gap;
    }

    /// <summary>
    /// 노드들의 타입 세팅
    /// </summary>
    /// <param name="_str"> 정수형으로 이루어진 문자열</param>
    private NodeType[] StringToNodeTypeArray(string _str)
    {
        string stringData = _str;
        int totalCount = gridXCount * gridYCount;

        //생성된 node 갯수만 type 받아오기
        if (_str.Length > totalCount)
        {
            stringData = _str.Substring(0, totalCount);
        }
        else if(_str.Length < totalCount)
        {
            for (int i = 0; i < totalCount - _str.Length; ++i)
            {
                stringData += "0";
            }
        }


        NodeType[] types = new NodeType[stringData.Length];
        for (int i=0; i< stringData.Length; ++i)
        {
            types[i] = (NodeType)Convert.ToInt32(stringData[i] - '0');
        }
        return types;
    }

    #region Create Grid (Custom Editor Version)
    public void GenerateGrid()
    {
        nodesType = StringToNodeTypeArray(nodesTypeString);

        CalcStartPos();
        CreateGrid();
        
        //custom Editor용
        Update = true;
    }

    private void CalcStartPos()
    {
        startPos = Vector3.zero;
    }

    private Vector3 CalcLocalPos(Vector2 Pos)
    {
        float offset = 0;
        if (Pos.x % 2 != 0)
        {
            offset = hexHeight / 2;
        }
        float x = startPos.x + Pos.x * (hexWidth*3/4);
        float y = startPos.y - Pos.y * hexHeight + offset;
        return new Vector3(x, y, 0);
    }

    private void CreateGrid()
    {
        int count = 0;
        for(int y=0; y< gridYCount; y++)
        {
            for (int x = 0; x < gridXCount; x++)
            {
                //GameObject hex = Instantiate(hexPrefab) as GameObject;
                Node hex = NGUITools.AddChild(this.transform.gameObject, hexPrefab).GetComponent<Node>();
                Vector2 pos = new Vector2(x, y);
                hex.transform.SetParent( this.transform);
                hex.transform.localScale = Vector3.one;
                hex.transform.localPosition = CalcLocalPos(pos);
                hex.name = "Node_" + count++;

                hex.Setting(nodesType[y * gridXCount + x], hex.transform.localPosition);
            }
        }
    }
    #endregion

    #region 사용미정
    private Transform topNode;
    public void AddRowNodes()
    {
        int count = 0;

        for (int x = 0; x<gridXCount; x++)
        {
            GameObject hex = NGUITools.AddChild(this.transform.gameObject, hexPrefab);
            Vector3 localPos = CalcLocalPos(new Vector2(x, 0));
            hex.transform.position = hex.transform.TransformPoint(hex.transform.InverseTransformPoint(topNode.transform.position) + localPos);
            hex.name = "new Node"+count++;
        }

    }
    #endregion

}
