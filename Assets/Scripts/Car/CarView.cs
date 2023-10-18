using UnityEngine;

namespace RaceArcade
{
    [RequireComponent(typeof(Rigidbody))]
    public class CarView : MonoBehaviour
    {
        private bool IsDrift = false;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void CheckCarOnDrift()
        {
            var driftAngle = Vector3.Dot(_rb.velocity.normalized, transform.forward);
            if(driftAngle >0.5)
            {
                IsDrift = true;
            }
        }
    }

}
