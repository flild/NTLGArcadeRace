using UnityEngine;
using UnityEngine.UI;
using RaceArcade.UI;

namespace RaceArcade
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Canvas _recordBoard;
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private RecordUI _recordFieldPrefub;
        [SerializeField] private RectTransform[] _RecordPosition;
        [SerializeField] private RaceTimer _raceTimer;
        [SerializeField] private CountdownUI _countdown;


        private float _curRecord;
        private void Start()
        {
            _countdown = Instantiate(_countdown, _mainCanvas.transform);
            _countdown.endedCountdown += OnEndCountdown;

        }
        private void OnDisable()
        {
            _countdown.endedCountdown -= OnEndCountdown;
        }
        public void ShowRecordBoard()
        {
            _recordBoard.gameObject.SetActive(true);
            for(int i = 1; i<10;i++)
            {
                _curRecord = PlayerPrefs.GetFloat("Record" + i, -1f);
                if (_curRecord == -1)
                    break;
                var record = Instantiate(_recordFieldPrefub, _RecordPosition[i-1].position ,Quaternion.identity ,_recordBoard.transform);
                record.SetRecord("player",_curRecord);
            }
        }
        public void UpdateRaceTimer(float time)
        {
            _raceTimer.UpdateTimer((double)time);
        }
        private void OnEndCountdown()
        {
            _countdown.gameObject.SetActive(false);
            //todo включение управления
        }

    }
}

