using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace RaceArcade.UI
{
    [RequireComponent(typeof(TMP_Text),typeof(Animator))]
    public class CountdownUI : MonoBehaviour
    {
        [SerializeField] private int time;
        private TMP_Text _countdownText;
        private Animator _animator;
        private int _animIDScaleNumber;
        public Action endedCountdown;

        private void Start()
        {
            _countdownText = GetComponent<TMP_Text>();
            _animator = GetComponent<Animator>();
            _animIDScaleNumber = Animator.StringToHash("ScaleNumber");
            OnEndNumberScale();
        }
        public void OnEndNumberScale()
        {
            _animator.SetBool(_animIDScaleNumber, false);
            StartCoroutine(CountdownLogic());
            if (time <= 0)
                endedCountdown?.Invoke();
            time--;
        }
        private IEnumerator CountdownLogic()
        {
            _countdownText.text = time.ToString();
            _animator.SetBool(_animIDScaleNumber, true);
            yield return null;
        }
    }
}

