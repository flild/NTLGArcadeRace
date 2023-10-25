using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace RaceArcade
{
    public class GameManager : MonoBehaviour
    {
        private float _startTime;
        private float _finishTime;
        private UIManager _UIManager;
        private bool _isStarted = false;
        [SerializeField] private Player _player;
        [SerializeField] private List<BotBrain> _bots;
        

     
        private void Awake()
        {
            _UIManager = GetComponent<UIManager>();
            FinishTrigger.PlayerFinishedLap += OnPlayerEndLap;
            _player.DisableInput();
            _UIManager.StartCoundown();

        }
        private void FixedUpdate()
        {
            if(_isStarted)
                _UIManager.UpdateRaceTimer(Time.time - _startTime);
        }
        private void OnDisable()
        {
            FinishTrigger.PlayerFinishedLap -= OnPlayerEndLap;
        }
        private void OnPlayerEndLap()
        {
            _isStarted = false;
            _player.DisableInput();
            PlayerFinish();
        }

        private void PlayerFinish()
        {
            float curRecord;
            _finishTime = Time.time - _startTime;
            Debug.Log("Player finished: " + _finishTime);
            for (int i =1;i<10;i++)
            {
                curRecord = PlayerPrefs.GetFloat("Record" + i, -1f);
                if( curRecord == -1 || _finishTime<curRecord)
                {
                    var temp_time = curRecord;
                    PlayerPrefs.SetFloat("Record" + i, _finishTime);
                    PlayerPrefs.SetString("RecordStr" + i, _UIManager.name);
                    _finishTime = temp_time;
                }
            }
            _UIManager.ShowRecordBoard();
        }
        public void StartRace()
        {
            _player.EnableInput();
            foreach(BotBrain bot in _bots)
            {
                bot.AllowToMove();
            }
            _isStarted = true;
            _startTime = Time.time;
        }

    }
}


