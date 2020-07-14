using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public UISprite img;

    public NodeData node;

  

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        //node = new NodeData();
        if (node == null) return;
        //img.spriteName = node.imageName;
    }

    public void OnClick()
    {
        GameObject.FindGameObjectWithTag("GridManager").GetComponent<GridManager>().curNode = this.gameObject;
    }
    
}
