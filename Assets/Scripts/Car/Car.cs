using UnityEngine;

namespace RaceArcade
{

    public class Car : MonoBehaviour
    {
        [SerializeField, Range(500,3000)]
        private int _motorForce;
        [SerializeField, Range(1, 90), Tooltip("ƒопустимый угол поворота колес в грудусах")]
        private float _steerAngle;

        public int motorForce { get { return _motorForce; } set { _motorForce = value; } }
        public float steerAngle { get { return _steerAngle; } set { _steerAngle = value; } }

    }
}

