using System;
using Codebase.Logic.Gameplay.Characters.Abstract.Gunner;
using Codebase.Logic.Gameplay.Characters.Common;
using Codebase.Logic.Gameplay.Characters.Implementations.Zombie;
using Codebase.Logic.Input;
using UnityEngine;
using Zenject;

namespace Codebase.Logic.Gameplay.Characters.Implementations.Gunner
{
    public class GunnerBehaviour : MonoBehaviour
    {
        [SerializeField] private GunnerAnimator _animator;
        [SerializeField] private GunnerShootingBehaviour _shooting;
        [SerializeField] private CharacterMovementBehaviour _movement;
        
        private IPlayerInput _playerInput;

        public event Action EnemyTouched;

        [Inject]
        public void Construct(IPlayerInput playerInput) => 
            _playerInput = playerInput;

        private void Update()
        {
            var currentAnimation = GunnerAnimation.Idle;
            
            var movementDirection = _playerInput.MovementDirection;

            if (_shooting.CanShoot && (_playerInput.IsSingleShot || 
                _playerInput.IsBursting))
            {
                currentAnimation = GunnerAnimation.Shooting;
                _shooting.Shoot();
            }
            
            _movement.SetDirection(movementDirection);
            
            if (movementDirection.HasValue) 
                currentAnimation = GunnerAnimation.Running;

            _animator.SetAnimation(currentAnimation);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var enemy = other.gameObject.GetComponent<ZombieBehaviour>();

            if (enemy) 
                EnemyTouched?.Invoke();
        }
    }
}