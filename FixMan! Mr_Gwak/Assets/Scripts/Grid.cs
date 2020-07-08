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

    Vector3 startPos;

    public Transform topNode;
    private int topIndex = 0;

    private void Start()
    {
        //AddGap();
        CalcStartPos();
        CreateGrid();
    }

    private void AddGap()
    {
        hexWidth += hexWidth * gap;
        hexHeight += hexHeight * gap;
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
                GameObject hex = NGUITools.AddChild(this.transform.gameObject, hexPrefab);
                Vector2 pos = new Vector2(x, y);
                //hex.parent = this.transform;
                hex.transform.SetParent( this.transform);
                hex.transform.localScale = Vector3.one;
                hex.transform.localPosition = CalcLocalPos(pos);
                hex.name = "Node_" + count++;
                
                Debug.Log(hex.name + hex.transform.position.ToString());
            }
        }
    }

    

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

}
