using UnityEngine;

namespace Codebase.Logic.Gameplay.Characters.Common
{
    public class CharacterMovementBehaviour : MonoBehaviour
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
            float velocityX = 0;
            float velocityY = _rb.velocity.y;
            
            if (_movementDirection == null)
            {
                _rb.velocity = new Vector3(velocityX, velocityY);
                return;
            }
            
            float rotation = _movementDirection > 0 ? 0 : 180;
            transform.rotation = Quaternion.Euler(0, rotation, 0);

            velocityX = CalculateVelocityX(_movementDirection.Value);
            _rb.velocity = new Vector3(velocityX, velocityY);
        }

        private float CalculateVelocityX(float direction) => 
            direction * _characterSpeed * Time.fixedDeltaTime * DeltaTimeCompensation;
    }
}