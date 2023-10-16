
using System;
using UnityEngine;
namespace RaceArcade
{
    public class FinishTrigger : MonoBehaviour
    {
        public static Action PlayerFinishedLap;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<Player>(out Player player))
            {
                PlayerFinishedLap?.Invoke();
            }
        }
    }
}

