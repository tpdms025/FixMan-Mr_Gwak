using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform hexPrefab;

    public int gridXCount = 11;
    public int gridYCount = 11;

    public float hexWidth = 0.5f;
    public float hexHeight = 0.5f;
    public float gap = 0;

    Vector3 startPos;

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

    private Vector3 CalcWorldPos(Vector2 gridCount)
    {
        float offset = 0;
        if (gridCount.x % 2 != 0)
        {
            offset = hexHeight / 2;
        }
        float x = startPos.x + gridCount.x * hexWidth;
        float y = startPos.y - gridCount.y * hexHeight + offset;
        return new Vector3(x, y, 0);
    }

    private void CreateGrid()
    {
        int count = 0;
        for(int y=0; y< gridYCount; y++)
        {
            for(int x=0; x< gridXCount; x++)
            {
                Transform hex = Instantiate(hexPrefab) as Transform;
                Vector2 gridCount = new Vector2(x, y);
                hex.position = CalcWorldPos(gridCount);
                Debug.Log(CalcWorldPos(gridCount).ToString());
                    hex.parent = this.transform;

                hex.name = "Node_" + count++;
                Debug.Log(hex.name + hex.position.ToString());
            }
        }
    }

    private void PushRowNodes()
    {

    }

  
}
