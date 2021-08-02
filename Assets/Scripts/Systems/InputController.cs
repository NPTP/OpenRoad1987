using UnityEngine;

namespace Systems
{
    public enum InputDirection
    {
        Left,
        Right,
        Forward,
        Back
    }
    
    public class InputController : MonoBehaviour
    {
        private const float AXIS_EPSILON = 0.1f;
        
        private int horizontal = 0;
        public int Horizontal => horizontal;
        private int vertical = 0;
        public int Vertical => vertical;

        public void RunInputCollection()
        {
            float axisHorizontal = Input.GetAxisRaw("Horizontal");
            if (axisHorizontal > AXIS_EPSILON) horizontal = 1;
            else if (axisHorizontal < -AXIS_EPSILON) horizontal = -1;
            else horizontal = 0;

            float axisVertical = Input.GetAxis("Vertical");
            if (axisVertical > AXIS_EPSILON) vertical = 1;
            else if (axisVertical < -AXIS_EPSILON) vertical = -1;
            else vertical = 0;
        }
    }
}
