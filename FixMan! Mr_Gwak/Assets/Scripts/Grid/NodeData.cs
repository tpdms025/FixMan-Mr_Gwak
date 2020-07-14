using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType { None = 0, Common, Rare, Unique, Legendary }

[System.Serializable]
public class NodeData
{
    #region Data
    [SerializeField] private NodeType m_type;              //타입
    public NodeType type
    {
        get { return m_type; }
        set
        {
            m_type = value;
            fillCount = (int)m_type;
            score = (int)m_type * 50;

        }
    }
    [SerializeField] private int m_curFillCount = 0;         //현재 채워진 꿀 횟수
    public int curFillCount
    {
        get { return m_curFillCount; }
        set
        {
            m_curFillCount = value;
            if (fillCount <= m_curFillCount)  //가득 찼다면
            {
                //hp 감소
            }
            else
            {
                imageName = "node_" + (int)type + "-" + m_curFillCount;
            }

        }
    }    

    [SerializeField] private int m_score;                  //점수
    public int score { get { return m_score; } set { m_score = value; } }
    [SerializeField] private int m_fillCount;              //채워야 할 횟수
    public int fillCount { get { return m_fillCount; } set { m_fillCount = value; } }
    [SerializeField] private string m_imageName;           //이미지이름
    public string imageName { get { return m_imageName; } set { m_imageName = value; } }

    [SerializeField] private Vector3 pos;
    public Vector3 position { get { return pos; } set { pos = value; } }

    #endregion
}
