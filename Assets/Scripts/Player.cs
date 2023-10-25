using UnityEngine;

namespace RaceArcade
{
    [RequireComponent(typeof(InputComponent))]
    public class Player : MonoBehaviour
    {
        private InputComponent _input;

        private void Awake()
        {
            _input = GetComponent<InputComponent>();
        }

        public void DisableInput()
        {
            _input.DisableInput();
        }

        public void EnableInput()
        {
            _input.EnableInput();
        }
    }
}

