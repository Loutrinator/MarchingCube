using System.Collections;
using System.Collections.Generic;
using MarchingCube;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MarchingCubeRenderer))]
class MarchingCubeRendererEditor : Editor {
    public override void OnInspectorGUI()
    {
        MarchingCubeRenderer renderer = (MarchingCubeRenderer)target;
        if (GUILayout.Button("Reload"))
        {
            renderer.ResetData();
        }
        
        DrawDefaultInspector();

    }
}