using UnityEngine;

namespace RaceArcade
{
    public class RacePoint : MonoBehaviour
    {
        [SerializeField] private int _targetIndex;


        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.1f,0.7f,0.1f,0.5f);
            Gizmos.DrawSphere(transform.position, 5.19f);

        }

        private void OnTriggerEnter(Collider other)
        {

            if(other.gameObject.TryGetComponent<BotBrain>(out BotBrain bot))
            {
                bot.IncreaseTarget(_targetIndex);
            }
        }
    }
}

