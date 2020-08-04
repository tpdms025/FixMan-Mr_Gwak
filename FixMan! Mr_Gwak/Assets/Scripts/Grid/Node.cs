using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType { None = 0, Level3, Level2, Level1 }

public class Node : MonoBehaviour
{
    private UISprite img;
    private UIButton btn;
    [SerializeField] private NodeType m_type;              //타입
    [SerializeField] private Vector3 m_pos;
    [SerializeField] private int m_score;                  //점수
    [SerializeField] private int m_fillCount;              //채워야 할 횟수
    [SerializeField] private int m_curFillCount = 0;         //현재 채워진 꿀 횟수
    [SerializeField] private string m_imageName;           //이미지이름


    public NodeType type { get { return m_type; } set { m_type = value; } }
    public Vector3 pos { get { return m_pos; } set { m_pos = value; } }
    public int score { get { return m_score; } set { m_score = value; } }
    public int fillCount { get { return m_fillCount; } set { m_fillCount = value; } }
    public string imageName
    {   get { return m_imageName; }
        set
        {
            m_imageName = value;
            img.spriteName = m_imageName;
            btn.normalSprite = m_imageName;
        }
    }
    public int curFillCount
    {
        get { return m_curFillCount; }
        set
        {
            m_curFillCount = value;
            imageName = "node_" + (int)type + "-" + m_curFillCount;
        }
    }



    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        img = GetComponent<UISprite>();
        btn = GetComponent<UIButton>();
    }


    public void Setting(NodeType _type, Vector3 _pos)
    {
        Init();

        type = _type;
        pos = _pos;

        fillCount = (int)type;
        score = (int)type * 50;
        imageName = "node_" + (int)type + "-" + curFillCount;
    }

    public void OnClick()
    {
        //currentNode 설정
        GameObject.FindGameObjectWithTag("GridManager").GetComponent<GridManager>().curNode = this.gameObject.GetComponent<Node>();
    }
    
}
