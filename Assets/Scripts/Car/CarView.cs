using UnityEngine;

namespace RaceArcade
{
    [RequireComponent(typeof(Rigidbody))]
    public class CarView : MonoBehaviour
    {
        private bool IsDrift = false;
        [SerializeField,Range(0,1f)] private float _minDriftAngle;
        [SerializeField]private ParticleSystem _tireSteamR, _tireSteamL;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
        private void FixedUpdate()
        {
            CheckCarOnDrift();
        }
        private void CheckCarOnDrift()
        {
            float driftAngle = Vector3.Dot(_rb.velocity.normalized, transform.forward);
            if(driftAngle <_minDriftAngle)
            {
                _tireSteamR.Play();
                _tireSteamL.Play();
                IsDrift = true;
            }
            else
            {
                _tireSteamR.Stop();
                _tireSteamL.Stop();
            }
        }
    }

}
