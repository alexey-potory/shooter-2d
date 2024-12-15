using System;
using Codebase.Logic.Gameplay.Characters.Abstract.Zombie;
using UnityEngine;

namespace Codebase.Logic.Gameplay.Characters.Implementations.Zombie
{
    public class ZombieBehaviour : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private ZombieAnimator _animator;
        [SerializeField] private ZombieShootingTarget _shootingTarget;
        [SerializeField] private ZombieHealthBar _healthBar;
        
        [Header("Settings")]
        [SerializeField] private int _maxHealth;

        public event Action<ZombieBehaviour> Killed;
        
        private Transform _target;
        
        private int _currentHealth;

        private void Awake()
        {
            if (_shootingTarget)
                _shootingTarget.Shot += OnShot;
        }

        private void OnEnable()
        {
            _currentHealth = _maxHealth;
            _animator.SetAnimation(ZombieAnimation.Walking);
            
            _healthBar.SetValue(1);
        }

        private void OnDestroy()
        {
            if (_shootingTarget)
                _shootingTarget.Shot -= OnShot;
        }

        private void OnShot()
        {
            _currentHealth -= 1;

            if (_currentHealth <= 0)
            {
                Killed?.Invoke(this);
                return;
            }
            
            _healthBar.SetValue((float)_currentHealth / _maxHealth);
        }
    }
}