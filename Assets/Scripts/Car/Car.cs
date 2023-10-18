using UnityEngine;

namespace RaceArcade
{
    [RequireComponent(typeof(Rigidbody),typeof(CarView))]
    public class Car : MonoBehaviour
    {
        [SerializeField, Range(500,3000)]
        private int _motorForce;
        [SerializeField, Range(1, 90), Tooltip("ƒопустимый угол поворота колес в грудусах")]
        private float _steerAngle;
        [SerializeField, Range(0, 1f), Tooltip("ћинимальное значение скал€рного произведени€ векторов скорости" +
                                                        " машины и еЄ направлени€, 1 едет пр€м, 0 едет боком")]
        private float _minDriftAngle;

        private bool IsDrift = false;
        private Rigidbody _rb;
        private CarView _carView;
        public int motorForce { get { return _motorForce; } set { _motorForce = value; } }
        public float steerAngle { get { return _steerAngle; } set { _steerAngle = value; } }
        

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _carView = GetComponent<CarView>();
        }
        private void FixedUpdate()
        {
            CheckCarOnDrift();
        }
        private void CheckCarOnDrift()
        {
            float driftAngle = Vector3.Dot(_rb.velocity.normalized, transform.forward);
            if (driftAngle < _minDriftAngle)
            {
                IsDrift = true;
                _carView.PlayDriftEffects(false);
            }
            else
            {
                IsDrift = false;
                _carView.StopDriftEffects(false);
            }
        }
    }
}

