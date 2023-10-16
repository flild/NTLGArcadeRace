using UnityEngine;

namespace RaceArcade
{
    [RequireComponent(typeof(Car))]
    public class MoveComponent : MonoBehaviour
    {
        private Car _car;
        [SerializeField] private WheelCollider _LfrontCol, _RfrontCol, _LbackCol, _RbackCol;
        [SerializeField] private Transform _LfrontTransf, _RfrontTransf, _LbackTransf, _RbackTransf;


        private void Start()
        {
            _car = GetComponent<Car>();
        }
        //call in fixed update
        public void Drive(Vector2 direction)
        {
            ForceBackWheels(direction.y);
            SteerCar(direction.x);
            UpdateWeelView();
        }
        public void BrakeVihicle(bool isPressed)
        {
            _LbackCol.brakeTorque = isPressed ? float.MaxValue : 0;
            _RbackCol.brakeTorque = isPressed ? float.MaxValue : 0;
        }
        private void ForceBackWheels(float directionY)
        {
            float scaledTorque = directionY * _car.motorForce;

            _RbackCol.motorTorque = scaledTorque;
            _LbackCol.motorTorque = scaledTorque;

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

