using UnityEngine;

namespace Movement
{
    public class CurveMarker
    {
        private float marker = 0.0f;

        public void Reset()
        {
            marker = 0.0f;
        }

        public void Add(float x)
        {
            marker += x;
            marker = Mathf.Clamp01(marker);
        }

        public void Subtract(float x)
        {
            marker -= x;
            marker = Mathf.Clamp01(marker);
        }

        public float Get()
        {
            marker = Mathf.Clamp01(marker);
            return marker;
        }

        public override string ToString()
        {
            return $"Curve marker value: {marker}";
        }
    }
}
