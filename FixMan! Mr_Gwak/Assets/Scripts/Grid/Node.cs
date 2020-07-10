using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType { None = 0, Common, Rare, Unique, Legendary }

public class Node : MonoBehaviour
{
    public Vector3 pos;     
    private NodeType _type;            //타입
    public NodeType type
    {
        get { return _type; }
        set
        {
            _type = value;
            fillCount = (int)_type;
        }
    }
    public int fillCount;             //채워야 할 횟수
    public int curHoneyCount = 0;         //현재 채워진 꿀 횟수
    public int score;
    public UISprite img;

    public void OnClick()
    {
        GameObject.FindGameObjectWithTag("GridManager").GetComponent<GridManager>().curNode = this.gameObject;
    }
    
}
