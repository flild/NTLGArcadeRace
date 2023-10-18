using UnityEngine;

namespace RaceArcade
{
    public class CarView : MonoBehaviour
    {
        [SerializeField, Tooltip("Ёффект дыма на колесах")]
        private ParticleSystem _RtireSteam, _LtireSteam;
        [SerializeField, Tooltip("—леды шин")]
        private TrailRenderer _RtireTrail,_LtireTrail;
        private bool _handBrake = false;


        public void PlayDriftEffects(bool isHandBrake)
        {
            if (isHandBrake) 
                _handBrake = true;
            _RtireSteam.Play();
            _LtireSteam.Play();
            _RtireTrail.emitting = true;
            _LtireTrail.emitting = true;
        }
        public void StopDriftEffects(bool isHandBrake)
        {
            if(isHandBrake)
                _handBrake = false;
            if (!_handBrake)
            {
                _RtireSteam.Stop();
                _LtireSteam.Stop();
                _RtireTrail.emitting = false;
                _LtireTrail.emitting = false;
                
            }

        }

    }

}
