using UnityEngine;
using TMPro;
namespace RaceArcade
{
    public class GameManager : MonoBehaviour
    {
        private float _startTime;
        private float _finishTime;
        private UIManager _UIManager;

     
        private void Awake()
        {
            _UIManager = GetComponent<UIManager>();
            FinishTrigger.PlayerFinishedLap += OnPlayerEndLap;
            _startTime = Time.time;

        }
        private void FixedUpdate()
        {
            _UIManager.UpdateRaceTimer(Time.time - _startTime);
        }
        private void OnDisable()
        {
            FinishTrigger.PlayerFinishedLap -= OnPlayerEndLap;
        }
        private void OnPlayerEndLap()
        {
            PlayerFinish();
        }

        private void PlayerFinish()
        {
            float curRecord;
            Debug.Log("Player finished");
            _finishTime = Time.time - _startTime;
            Debug.Log(_finishTime);
            for(int i =1;i<10;i++)
            {
                curRecord = PlayerPrefs.GetFloat("Record" + i, -1f);
                if( curRecord == -1 || _finishTime<curRecord)
                {
                    var temp_time = curRecord;
                    PlayerPrefs.SetFloat("Record" + i, _finishTime);
                    _finishTime = temp_time;
                }
            }
            _UIManager.ShowRecordBoard();
        }
    }
}


