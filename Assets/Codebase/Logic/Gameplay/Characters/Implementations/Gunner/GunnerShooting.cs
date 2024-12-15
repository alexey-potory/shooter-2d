using UnityEngine;

namespace Codebase.Logic.Gameplay.Characters.Implementations.Gunner
{
    public class GunnerShooting : MonoBehaviour
    {
        [SerializeField] private float _bulletsPerSecond;
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private float _bulletSpeed = 20;

        private float _timeout;

        public float BulletSpeed => _bulletSpeed;
        public Transform ShootingPoint => _shootingPoint;

        public bool OnTimeout => Mathf.Abs(_timeout) > Mathf.Epsilon;
        public void SetTimeout() => _timeout = 1f / _bulletsPerSecond;
        
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