using UnityEngine;
using UnityEngine.InputSystem;

namespace RaceArcade
{
    [RequireComponent(typeof(MoveComponent))]
    public class InputComponent : MonoBehaviour
    {
        private CarInput _input;
        private MoveComponent _move;
        private void Awake()
        {
            _input = new CarInput();
        }
        private void Start()
        {
            _move = GetComponent<MoveComponent>();
        }
        private void OnEnable()
        {
            _input.Enable();
            _input.CarInputMap.HandBrake.started += OnPutBrakes;
            _input.CarInputMap.HandBrake.canceled += OnCanceledBrake;
        }
        private void FixedUpdate()
        {
            Vector2 direction = _input.CarInputMap.Move.ReadValue<Vector2>();
            _move.Drive(direction);
        }
        private void OnDisable()
        {
            _input.Disable();
            _input.CarInputMap.HandBrake.started -= OnPutBrakes;
            _input.CarInputMap.HandBrake.canceled -= OnCanceledBrake;
        }
        public void DisableInput()
        {
            _input.Disable();
        }

        public void EnableInput()
        {
            _input.Enable();
        }

        private void OnPutBrakes(InputAction.CallbackContext context)
        {
            _move.BrakeVihicle(true);
        }
        private void OnCanceledBrake(InputAction.CallbackContext context)
        {
            _move.BrakeVihicle(false);
        }

    }
}

