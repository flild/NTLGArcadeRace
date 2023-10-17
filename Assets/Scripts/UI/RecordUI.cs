using UnityEngine;
using TMPro;

namespace RaceArcade.UI
{
    public class RecordUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerName, _playerScore;

        public void SetRecord(string name, float score)
        {
            _playerName.text = name;
            _playerScore.text = score.ToString();
        }
    }
}

