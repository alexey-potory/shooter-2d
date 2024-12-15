using Codebase.Logic.Gameplay.Shooting;
using UnityEngine;
using Zenject;

namespace Codebase.Logic.Gameplay.Characters.Implementations.Gunner
{
    public class GunnerShootingBehaviour : MonoBehaviour
    {
        [SerializeField] private float _bulletsPerSecond;
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private float _bulletSpeed = 20;

        private ShootingSystem _system;

        public bool CanShoot => enabled && !OnTimeout;
        
        private bool OnTimeout => Mathf.Abs(_timeout) > Mathf.Epsilon;
        private void SetTimeout() => _timeout = 1f / _bulletsPerSecond;
        
        private float _timeout;

        [Inject]
        public void Construct(ShootingSystem system) => 
            _system = system;

        public void Shoot()
        {
            if (!CanShoot)
                return;
            
            var direction = Mathf.Abs(transform.rotation.y) < Mathf.Epsilon ? 1 : -1;
            var position = _shootingPoint.position;

            _system.Shoot(position, direction, _bulletSpeed);
            
            SetTimeout();
        }
        
        private void Update()
        {
            if (!OnTimeout) 
                return;
            
            _timeout -= Time.deltaTime;
                
            if (_timeout < 0)
                _timeout = 0;
        }
    }
}