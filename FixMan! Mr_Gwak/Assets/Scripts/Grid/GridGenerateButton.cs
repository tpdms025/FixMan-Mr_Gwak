using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Grid))]
public class GridGenerateButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Grid generator = (Grid)target;
        if(GUILayout.Button("Generate Grid"))
        {
            //기존의 오브젝트 삭제
            if (generator.Update)               
            {
                GameObject[] childs;
                int count = generator.transform.childCount;
                childs = new GameObject[count];
                for (int i = 0; i < count; i++)
                {
                    childs[i] = generator.transform.GetChild(i).gameObject;
                }
                foreach (GameObject c in childs)
                {
                    DestroyImmediate(c.gameObject);
                }
            }

            generator.GenerateGrid();
        }
    }

}
