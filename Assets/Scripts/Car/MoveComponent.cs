using UnityEngine;

namespace RaceArcade
{
    [RequireComponent(typeof(Car),typeof(CarView))]
    public class MoveComponent : MonoBehaviour
    {
        private Car _car;
        private Rigidbody _rb;
        private CarView _carView;
        [SerializeField] private WheelCollider _LfrontCol, _RfrontCol, _LbackCol, _RbackCol;
        [SerializeField] private Transform _LfrontTransf, _RfrontTransf, _LbackTransf, _RbackTransf;
        [SerializeField] private Vector3 _centerMass;



        private void Start()
        {
            _car = GetComponent<Car>();
             _rb = _car.GetComponent<Rigidbody>();
            _carView = _car.GetComponent<CarView>();
            _rb.centerOfMass = _centerMass;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.TransformPoint(_centerMass), .3f);
        }

        //call in fixed update
        public void Drive(Vector2 direction)
        {
            ForceWheels(direction.y);
            SteerCar(direction.x);
            UpdateWeelView();
        }
        public void BrakeVihicle(bool isPressed)
        {
            if(isPressed)
            {
                _LbackCol.brakeTorque =  float.MaxValue;
                _RbackCol.brakeTorque = float.MaxValue;
                _carView.PlayDriftEffects(true);
            }
            else
            {
                _LbackCol.brakeTorque = 0;
                _RbackCol.brakeTorque = 0;
                _carView.StopDriftEffects(true);
            }
            
        }
        private void ForceWheels(float directionY)
        {

            float scaledTorque = directionY * _car.motorForce;
            _RbackCol.motorTorque = scaledTorque;
            _LbackCol.motorTorque = scaledTorque;
            _RfrontCol.motorTorque = scaledTorque / 4;
            _LfrontCol.motorTorque = scaledTorque / 4;

        }

        private void SteerCar(float directionX)
        {
            var steerAngl = _car.steerAngle * directionX;
            _RfrontCol.steerAngle = Mathf.Lerp(_RfrontCol.steerAngle, steerAngl,0.3f);
            _LfrontCol.steerAngle = Mathf.Lerp(_LfrontCol.steerAngle, steerAngl, 0.3f); ;
        }
        //todo по идеи вынести это в CarView, но пока такой метод один
        private void UpdateWeelView()
        {
            Vector3 pos;
            Quaternion rot;
            _LfrontCol.GetWorldPose(out pos, out rot);
            _LfrontTransf.position = pos;
            _LfrontTransf.rotation = rot;

            _RfrontCol.GetWorldPose(out pos, out rot);
            _RfrontTransf.position = pos;
            _RfrontTransf.rotation = rot;

            _LbackCol.GetWorldPose(out pos, out rot);
            _LbackTransf.position = pos;
            _LbackTransf.rotation = rot;

            _RbackCol.GetWorldPose(out pos, out rot);
            _RbackTransf.position = pos;
            _RbackTransf.rotation = rot;
        }

        
    }
}

