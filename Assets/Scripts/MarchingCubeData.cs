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

        public MarchingCubeData(int width, int height, int depth)
        {
            points = new List<float>();
            
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
                    }
                }
            }
        }

        public void setPointValue(int x, int y, int z, float value)
        {
            points[z * dataHeight * dataWidth + y * dataWidth + x] = value;
        }
        public float getPointValue(int x, int y, int z)
        {
            return points[z * dataHeight * dataWidth + y * dataWidth + x];
        }
    }
}