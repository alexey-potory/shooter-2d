using UnityEngine;

namespace Codebase.Logic.Gameplay.Characters.Implementations
{
    public class CharacterMovement : MonoBehaviour
    {
        private const float DeltaTimeCompensation = 100;
        
        [SerializeField] private float _characterSpeed;
        [SerializeField] private Rigidbody2D _rb;

        private float? _movementDirection;
        
        public void SetDirection(float? direction)
        {
            if (!direction.HasValue)
            {
                _movementDirection = null;
                return;
            }
            
            _movementDirection = Mathf.Sign(direction.Value);
        }

        private void FixedUpdate()
        {
            if (_movementDirection == null)
            {
                _rb.velocity = Vector2.zero;
                return;
            }
            
            float rotation = _movementDirection > 0 ? 0 : 180;

            transform.rotation = Quaternion.Euler(0, rotation, 0);
            _rb.velocity = new Vector3(_movementDirection.Value * _characterSpeed * Time.fixedDeltaTime * DeltaTimeCompensation, 0);
        }
    }
}