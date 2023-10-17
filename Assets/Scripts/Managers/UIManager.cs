using UnityEngine;
using UnityEngine.UI;
using RaceArcade.UI;

namespace RaceArcade
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Canvas _recordBoard;
        [SerializeField] private RecordUI _recordFieldPrefub;
        [SerializeField] private RectTransform[] _RecordPosition;

        private float _curRecord;
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

    }
}

