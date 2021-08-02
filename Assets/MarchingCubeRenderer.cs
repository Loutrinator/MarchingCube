using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingCubeRenderer : MonoBehaviour
{
    public int width;
    public int depth;
    public int height;

    [Range(0f,1f)]
    public float floor = 0.5f;
    
    private MarchingCubeData data;

    public void ResetData()
    {
        data = new MarchingCubeData(width, depth, height);
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 1, 1f);
        for (int y = 0; y < height; ++y)
        {
            for (int z = 0; z < depth; ++z)
            {
                for (int x = 0; x < width; ++x)
                {
                    float dataAtPoint = data.points[z * depth * width + y*width + x];
                    Gizmos.color = new Color(1, 1-dataAtPoint, 1-dataAtPoint, 1f);
                    float size = dataAtPoint <= floor ? 0.1f : 0f;
                    Gizmos.DrawCube(new Vector3(x, y, z)-new Vector3(width/2f, depth/2f, height/2f), Vector3.one*size);
                }
            }
        }
    }
}
