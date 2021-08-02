using Systems;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(InputController))]
    public class PlayerMovement : MonoBehaviour
    {
        private float topSpeed = 1.5f;
        private float topSteerSpeed = 6.0f;
        
        [SerializeField] private AnimationCurve accelerationCurve;
        private float AccelSpeed => accelerationCurve.Evaluate(gasCurveMarker.Get()) * topSpeed;
        public float AccelCurve => accelerationCurve.Evaluate(gasCurveMarker.Get());
        
        [SerializeField] private AnimationCurve brakingCurve;
        private float BrakeSpeed => brakingCurve.Evaluate(gasCurveMarker.Get()) * topSpeed;
        
        [SerializeField] private AnimationCurve steerCurve;
        private float SteerSpeed => steerCurve.Evaluate(steerCurveMarker.Get()) * topSteerSpeed;

        private int steerDirection = 0;

        private CurveMarker gasCurveMarker = new CurveMarker();
        private CurveMarker steerCurveMarker = new CurveMarker();
        
        private InputController inputController;
        
        // Values must be within the interval [0.0, 1.0]
        private float accelerationPerSecond = 0.3f;
        private float decelerationPerSecond = 0.05f;
        private float brakeSlowPerSecond = 0.8f;
        private float steerPerSecond = 0.5f;
        private float recenterPerSecond = 2.0f;

        private void Awake()
        {
            inputController = GetComponent<InputController>();
        }

        private void Update()
        {
            inputController.RunInputCollection();
            GasAndBrake();
            Steering();
            print($"Gas: {gasCurveMarker}, Steer: {steerCurveMarker}");
        }

        private void GasAndBrake()
        {
            if (inputController.Vertical == 0)
            {
                gasCurveMarker.Subtract(decelerationPerSecond * Time.deltaTime);
            }
            else if (inputController.Vertical == 1)
            {
                gasCurveMarker.Add(accelerationPerSecond * Time.deltaTime);
            }
            else if (inputController.Vertical == -1)
            {
                gasCurveMarker.Subtract(brakeSlowPerSecond * Time.deltaTime);
            }
            
            transform.position += transform.forward * AccelSpeed;
        }

        private void Steering()
        {
            if (inputController.Horizontal == 0)
            {
                steerCurveMarker.Subtract(recenterPerSecond * Time.deltaTime);
            }
            else if (inputController.Horizontal == 1)
            {
                steerDirection = 1;
                steerCurveMarker.Add(steerPerSecond * Time.deltaTime);
            }
            else if (inputController.Horizontal == -1)
            {
                steerDirection = -1;
                steerCurveMarker.Add(steerPerSecond * Time.deltaTime);
            }
            
            transform.Rotate(Vector3.up * (steerDirection * SteerSpeed));
        }
    }
}
