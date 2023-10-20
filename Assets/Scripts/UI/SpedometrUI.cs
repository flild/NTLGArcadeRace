using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace RaceArcade.UI
{
    public class SpedometrUI : MonoBehaviour
    {
        [SerializeField] private Image _speedArrow;
        //для корректно отображения
        private float _offsetArrow = 135;

        public IEnumerator UpdateSpeedArrow(float speed, float delay)
        {
            float offsetSpeed = speed - _offsetArrow;
            while (delay > 0.01)
            {
                _speedArrow.transform.rotation = Quaternion.Slerp(_speedArrow.transform.rotation,Quaternion.Euler(0, 0, -offsetSpeed), Time.deltaTime);
                delay-=Time.deltaTime;
                yield return null;
            }
            
            yield return null;
        }
    }

}
