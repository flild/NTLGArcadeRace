using System.Collections;
using UnityEngine;

namespace RaceArcade.UI
{
    public class PlayerCarUI : MonoBehaviour
    {
        private float _speedUpdateDelay = 0.3f;
        private const float c_ConvertMsToKMH = 3.6f;
        [SerializeField] SpedometrUI _speedometr;
        private void Start()
        {
            StartCoroutine(CalculateSpeedKMH());
        }
        private IEnumerator CalculateSpeedKMH()
        {
            var prevPos = transform.position;
            while (true)
            {
                var distance = Vector3.Distance(prevPos, transform.position);
                var speed = (float)System.Math.Round(distance / _speedUpdateDelay * c_ConvertMsToKMH, 1);
                StartCoroutine(_speedometr.UpdateSpeedArrow(speed, _speedUpdateDelay));
                prevPos = transform.position;
                yield return new WaitForSeconds(_speedUpdateDelay);
            }
        }
    }


}
