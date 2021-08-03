using UnityEngine;

namespace MarchingCube
{
    public class CubeCell
    {
        public Vector3[] p;
        public float[] v;

        public CubeCell()
        {
            p = new Vector3[8];
            v = new float[8];
        }
    }
}