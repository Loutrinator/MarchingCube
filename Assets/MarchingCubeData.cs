using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingCube
{
    public class MarchingCubeData
    {
        public List<float> points { get; }
        private int dataWidth = 0;
        private int dataDepth = 0;
        private int dataHeight = 0;
        private int nbPoints = 0;

        public MarchingCubeData(int width, int depth, int height, float scale)
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
                        points.Add(0);
                        Vector3 pos = new Vector3(x / (float) width * scale, y / (float) depth * scale,
                            z / (float) height * scale);
                        float perlin = Mathf.PerlinNoise(pos.x, pos.y);
                        points.Add(perlin);
                        ///setPointValue(x,y,z,val);
                    }
                }
            }
        }

        public void setPointValue(int x, int y, int z, float value)
        {
            points[z * dataDepth * dataWidth + y * dataWidth + x] = value;
        }
        public float getPointValue(int x, int y, int z)
        {
            return points[z * dataDepth * dataWidth + y * dataWidth + x];
        }
    }
}