using UnityEngine;

namespace RaceArcade
{
    [RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
    public class CarSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _EngineAudio;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;

        [SerializeField] private float _minPitch;
        [SerializeField] private float _maxPitch;
        private float _currentSpeed;
        private float _PitchfromCar;

        private Rigidbody _carRb;
        private void Awake()
        {
            _carRb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            PlayEngineAudio();
        }
        private void PlayEngineAudio()
        {
            _currentSpeed = _carRb.velocity.magnitude;
            _PitchfromCar = _carRb.velocity.magnitude / 50f;

            if(_currentSpeed < _minSpeed)
            {
                _EngineAudio.pitch = _minPitch;
            }
            if(_currentSpeed>_minSpeed && _currentSpeed < _maxSpeed)
            {
                _EngineAudio.pitch = _minPitch + _PitchfromCar;
            }
            if(_currentSpeed > _maxSpeed)
            {
                _EngineAudio.pitch = _maxPitch;
            }
        }

    }
}

