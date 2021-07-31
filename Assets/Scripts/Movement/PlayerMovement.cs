using Systems;
using UnityEngine;

namespace Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        private float accelerationPerSecond = 4.0f;
        private float decelerationPerSecond = 8.0f;
        private float topSpeed = 20.0f;
        private float turnSpeed = 20.0f;
        private float topTurnSpeed = 90.0f;

        private float currentSpeed = 0.0f;
        private int lastThrustSign = 0;

        private void Update()
        {
            Steering();
            GasAndBrake();
        }

        private void Steering()
        {
            if (InputController.Horizontal == 0 || currentSpeed == 0.0f) return;

            int rotateSign = 1;
            if (lastThrustSign == -1) rotateSign = -1;

            float effectiveTurnSpeed = Mathf.Clamp(turnSpeed * currentSpeed, 0.0f, topTurnSpeed);
            
            transform.Rotate(Vector3.up * (rotateSign * InputController.Horizontal * effectiveTurnSpeed * Time.deltaTime), Space.Self);
        }

        private void GasAndBrake()
        {
            if (InputController.Vertical == 0)
            {
                currentSpeed -= decelerationPerSecond * Time.deltaTime;
            }
            else
            {
                currentSpeed += accelerationPerSecond * Time.deltaTime;
                lastThrustSign = InputController.Vertical;
            }
            
            currentSpeed = Mathf.Clamp(currentSpeed, 0.0f, topSpeed);
            transform.position += transform.forward * (lastThrustSign * (currentSpeed * Time.deltaTime));
        }
    }
}
