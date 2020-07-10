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
            generator.GenerateGrid();
        }
    }
}
