using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingCubeRenderer : MonoBehaviour
{
    public int width;
    public int depth;
    public int height;
    public float scale;

    [Range(0f,1f)]
    public float floor = 0.5f;

    public float perlinHeight = 10;
    
    private MarchingCubeData data;

    public void ResetData()
    {
        data = new MarchingCubeData(width, depth, height,scale);
        ComputeData();
    }

    private void ComputeData()
    {
        for (int z = 0; z < depth; ++z)
        {
            for (int x = 0; x < width; ++x)
            {
                Vector2 pos = new Vector2(x / (float)width * scale,  z / (float)height * scale);
                float perlin = Mathf.PerlinNoise(pos.x, pos.y) * perlinHeight;
                for (int y = 0; y < height; ++y)
                {
                    if (y < perlin)
                    {
                        data.setPointValue(x, y, z,1);
                    }
                    else
                    {
                        data.setPointValue(x, y, z,0);
                    }
                }
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 1, 1f);
        Vector3 offset = new Vector3(width / 2f, depth / 2f, height / 2f);
        for (int y = 0; y < height; ++y)
        {
            for (int z = 0; z < depth; ++z)
            {
                for (int x = 0; x < width; ++x)
                {
                    float dataAtPoint = data.points[z * depth * width + y*width + x];
                    if (x == 1 && y == 2 && z == 5)
                    {
                        Gizmos.color = new Color(0, 1, 0, 1f);
                    }
                    else
                    {
                        Gizmos.color = new Color(1, 1-dataAtPoint, 1-dataAtPoint, 1f);
                    }
                    float size = dataAtPoint >= floor ? 0.1f : 0f;
                    Gizmos.DrawCube(new Vector3(x, y, z)- offset, Vector3.one*size);
                }
            }
        }
    }
}
