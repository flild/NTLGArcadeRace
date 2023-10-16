using UnityEngine;
using TMPro;
namespace RaceArcade
{
    public class GameManager : MonoBehaviour
    {
        private float _startTime;
        [SerializeField] private TMP_Text _timer;
        private void Awake()
        {
            FinishTrigger.PlayerFinishedLap += OnPlayerEndLap;
            _startTime = Time.time;
        }
        private void FixedUpdate()
        {
            //обрезать до двух знаков после запятой
            //вынести в отдельную корутину, чтобы стопать её на финише
            //и чтобы начинать не со старта
            _timer.text = "Timer: " + (Time.time - _startTime);
        }
        private void OnDisable()
        {
            FinishTrigger.PlayerFinishedLap -= OnPlayerEndLap;
        }
        private void OnPlayerEndLap()
        {
            Debug.Log("Player finished");
            Debug.Log(Time.time - _startTime);
        }
    }
}


