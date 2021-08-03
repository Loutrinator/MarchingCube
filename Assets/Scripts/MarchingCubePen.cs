using System;
using System.Collections;
using System.Collections.Generic;
using MarchingCube;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class MarchingCubePen : MonoBehaviour
{
    public MarchingCubeRenderer mcRenderer;
    private int drawingMode;//0 nothing, 1 draw, -1 erase

    private float radius = 3f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            drawingMode = 1;
        }else if (Input.GetMouseButton(1))
        {
            
            drawingMode = -1;
        }
        else
        {
            drawingMode = 0;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        scroll = scroll > 0 ? 1 : scroll < 0 ? -1 : 0;
        radius += scroll * 0.1f;
        if (scroll != 0)
        {
            setScale();
        }
    }

    private void FixedUpdate()
    {
        MoveCursor();
        Paint();
    }

    private void Paint()
    {
        mcRenderer.getClosestCell(transform.position);
        //float distSqr = gridPoint.x*gridPoint.x + gridPoint.y*gridPoint.y + gridPoint.z*gridPoint.z;
        //if (distSqr < radiusSqr)
        //    gridPoints.Add(gridPoint);
    }

    private void MoveCursor()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f))
        {
            transform.position = hit.point;
        }
    }

    private void setScale()
    {
        transform.localScale = Vector3.one * (radius * 2f);
    }
}
