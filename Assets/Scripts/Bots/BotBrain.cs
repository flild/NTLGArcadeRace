using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RaceArcade
{
    [RequireComponent(typeof(MoveComponent))]
    public class BotBrain : MonoBehaviour
    {
        [SerializeField] private List<RacePoint> _racePoints;
        [SerializeField,Range(0, 5)] private float _minAngleTorotation;
        [SerializeField, Range(0, 3)] private float _stuckCheckDelay;
        [SerializeField, Range(0, 10)] private float _minLengthToReturn;
        private Vector3 _currentPointPos;
        private int _currentIndex;
        private MoveComponent _moveComponent;
        private bool _isCanMove = false;

        private void Start()
        {
            _moveComponent = GetComponent<MoveComponent>();
            _currentPointPos = _racePoints[0].transform.position;
            StartCoroutine(StuckCheck());
        }
        private void FixedUpdate()
        {
            if(_isCanMove)
                MoveToNextPoint();
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, _currentPointPos);
        }
        public void IncreaseTarget(int index)
        {
            _currentIndex = index;
            try
            {
                _currentPointPos = _racePoints[index + 1].transform.position;
            }
            catch(IndexOutOfRangeException e)
            {
                _currentPointPos = _racePoints[0].transform.position;
            }
        }
        private void MoveToNextPoint()
        {
            int xValue = GetAngle();
            Vector2 targetDirection = new Vector2(xValue, 1);
            _moveComponent.Drive(targetDirection);
        }
        private int GetAngle()
        {
            var targetPos = _currentPointPos;
            targetPos.y = transform.position.y;

            var direction = targetPos - transform.position;
            float angle = Vector3.SignedAngle( transform.forward, direction, transform.up);
            if (angle < -_minAngleTorotation)
                return -1;
            else if (angle > _minAngleTorotation)
                return 1;
            else
                return 0;
        }

        private IEnumerator StuckCheck()
        {
            Vector3 delayPosition = transform.position;
            while (true)
            {
                yield return new WaitForSeconds(_stuckCheckDelay);
                if (!_isCanMove)
                    continue;
                var lengthVector = transform.position - delayPosition;
                float length = lengthVector.magnitude;
                if (length < _minLengthToReturn)
                    transform.position = _racePoints[_currentIndex].transform.position;
                else
                    delayPosition = transform.position;
            }
        }
        public void AllowToMove()
        {
            _isCanMove = true;
        }
        public void disallowToMove()
        {
            _isCanMove = false;
        }
    }

}
