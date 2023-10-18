using UnityEngine;
using TMPro;
using System;

namespace RaceArcade.UI
{
    public class RaceTimer : MonoBehaviour
    {
        private TMP_Text _timer;
        private void Awake()
        {
            _timer = GetComponent<TMP_Text>();
        }
        public void UpdateTimer(double time)
        {
            time = time;
            double MM = Math.Truncate(time / 60);
            double SS = Math.Round(time % 60,0);
            double DD =(Math.Round(time % 1,2)*100);

            _timer.text = $"Time {ToStr(MM)}:{ToStr(SS)}:{ToStr(DD)}";
        }    
        private string ToStr(double value)
            => value<10 ? "0" +value.ToString() : value.ToString();
    }
}

