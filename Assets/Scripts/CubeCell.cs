using UnityEngine;

namespace MarchingCube
{
    public class CubeCell
    {
        public Vector3[] position;
        public float[] values;

        public CubeCell()
        {
            position = new Vector3[8];
            values = new float[8];
        }
    }
}