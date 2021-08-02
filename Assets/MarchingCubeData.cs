using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingCubeData
{
    public List<float> points {get;}
    private int dataWidth = 0;
    private int dataDepth = 0;
    private int dataHeight = 0;
    private int nbPoints = 0;
    public MarchingCubeData(int width, int depth, int height)
    {
        dataWidth = width;
        dataDepth = depth;
        dataHeight = height;
        nbPoints = width * depth * height;
        
        points = new List<float>();
        for (int y = 0; y < dataHeight; ++y)
        {
            for (int z = 0; z < dataDepth; ++z)
            {
                for (int x = 0; x < dataWidth; ++x)
                {
                    float val = z / (float)height;
                    points.Add(val);
                    ///setPointValue(x,y,z,val);
                }
            }
        }
    }

    public void setPointValue(int x, int y, int z, float value)
    {
        
    }
}
