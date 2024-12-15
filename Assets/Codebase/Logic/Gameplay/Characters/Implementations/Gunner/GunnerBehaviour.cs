using System;
using Codebase.Logic.Gameplay.Characters.Abstract.Gunner;
using Codebase.Logic.Gameplay.Characters.Implementations.Zombie;
using Codebase.Logic.Gameplay.Shooting;
using Codebase.Logic.Input;
using UnityEngine;
using Zenject;

namespace Codebase.Logic.Gameplay.Characters.Implementations.Gunner
{
    public class GunnerBehaviour : MonoBehaviour
    {
        [SerializeField] private GunnerAnimator _gunnerAnimator;
        [SerializeField] private GunnerShooting _gunnerShooting;
        [SerializeField] private CharacterMovement _characterMovement;
        
        private IPlayerInput _playerInput;
        private ShootingSystem _shootingSystem;

        public event Action EnemyTouched;

        [Inject]
        public void Construct(IPlayerInput playerInput, ShootingSystem shootingSystem)
        {
            _playerInput = playerInput;
            _shootingSystem = shootingSystem;
        }

        private void Update()
        {
            var currentAnimation = GunnerAnimation.Idle;
            
            var movementDirection = _playerInput.MovementDirection;

            if (_playerInput.IsBursting)
            {
                PerformBurstShooting();
                currentAnimation = GunnerAnimation.Shooting;
            }
            else if (_playerInput.IsSingleShot)
            {
                PerformSingleShot();
                currentAnimation = GunnerAnimation.Shooting;
            }

            _characterMovement.SetDirection(movementDirection);
            
            if (movementDirection.HasValue) 
                currentAnimation = GunnerAnimation.Running;

            _gunnerAnimator.SetAnimation(currentAnimation);
        }

        private void PerformSingleShot()
        {
            var direction = Mathf.Abs(transform.rotation.y) < Mathf.Epsilon ? 1 : -1;
            var position = _gunnerShooting.ShootingPoint.position;

            _shootingSystem.Shoot(position, direction, _gunnerShooting.BulletSpeed);
        }
        
        private void PerformBurstShooting()
        {
            if (_gunnerShooting.OnTimeout)
                return;
                
            var direction = Mathf.Abs(transform.rotation.y) < Mathf.Epsilon ? 1 : -1;
            var position = _gunnerShooting.ShootingPoint.position;

            _shootingSystem.Shoot(position, direction, _gunnerShooting.BulletSpeed);
            _gunnerShooting.SetTimeout();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var enemy = other.gameObject.GetComponent<ZombieBehaviour>();

            if (enemy) 
                EnemyTouched?.Invoke();
        }
    }
}