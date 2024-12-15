using UnityEngine;
using UnityEngine.InputSystem;

namespace Codebase.Logic.Input
{
    public class NewPlayerInput : MonoBehaviour, IPlayerInput
    {
        [SerializeField] private InputActionAsset _inputAction;
        
        private InputAction _moveAction;
        private InputAction _singleShotAction;
        private InputAction _burstAction;

        private void Start()
        {
            _moveAction = _inputAction.FindAction("Move");
            _moveAction.Enable();
            
            _singleShotAction = _inputAction.FindAction("SingleShot");
            _singleShotAction.Enable();
            
            _burstAction = _inputAction.FindAction("Burst");
            _burstAction.Enable();
        }

        public float? MovementDirection => GetDirection();
        public bool IsSingleShot => _singleShotAction.WasPerformedThisFrame();
        public bool IsBursting => _burstAction.ReadValue<float>() > 0;

        private float? GetDirection()
        {
            var direction = _moveAction.ReadValue<float>();

            if (Mathf.Abs(direction) < Mathf.Epsilon)
                return null;

            return direction;
        }
    }
}