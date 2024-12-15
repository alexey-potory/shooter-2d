using System.Collections.Generic;
using Codebase.Logic.Factories;
using Codebase.Logic.Gameplay.Camera;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Codebase.Logic.Gameplay.Shooting
{
    public class ShootingSystem : ITickable
    {
        private readonly ProjectileFactory _factory;
        private readonly GameplayCameraBehaviour _camera;
        private readonly AmmoSystem _ammoSystem;

        private readonly IObjectPool<ProjectileBehaviour> _pool;
        private readonly List<ProjectileBehaviour> _activeProjectiles = new();

        private readonly GameObject _poolObject = new("Bullets");

        public ShootingSystem(ProjectileFactory factory, GameplayCameraBehaviour camera, AmmoSystem ammoSystem)
        {
            _factory = factory;
            _camera = camera;
            _ammoSystem = ammoSystem;

            _pool = new ObjectPool<ProjectileBehaviour>(OnProjectileCreate, OnProjectileGet, OnProjectileRelease, maxSize: 10);
        }

        public void Shoot(Vector3 position, float direction, float speed)
        {
            var projectile = _pool.Get();

            projectile.transform.position = position;
            projectile.SetDirection(direction);
            projectile.SetSpeed(speed);

            _activeProjectiles.Add(projectile);
            _ammoSystem.CurrentAmmo -= 1;
        }

        public void Tick()
        {
            var bounds = _camera.Bounds;
            
            if (!bounds.HasValue)
                return;
            
            for (var index = _activeProjectiles.Count - 1; index >= 0; index--)
            {
                var projectile = _activeProjectiles[index];
                
                if (!bounds.Value.Contains(projectile.transform.position))
                {
                    Release(projectile);
                    continue;
                }

                var offset = projectile.Direction * projectile.Speed * Time.deltaTime;
                projectile.transform.position += new Vector3(offset, 0);
            }
        }

        private ProjectileBehaviour OnProjectileCreate()
        {
            var bullet = _factory.CreateBullet();
            bullet.transform.SetParent(_poolObject.transform);

            bullet.HitTarget += OnProjectileHitTarget;
            
            return bullet;
        }

        private void OnProjectileHitTarget(ProjectileBehaviour source, ShootingTarget target)
        {
            Release(source);
            target.OnShot();
        }

        private static void OnProjectileGet(ProjectileBehaviour projectile) => 
            projectile.gameObject.SetActive(true);

        private static void OnProjectileRelease(ProjectileBehaviour projectile) => 
            projectile.gameObject.SetActive(false);

        private void Release(ProjectileBehaviour projectile)
        {
            _activeProjectiles.Remove(projectile);
            _pool.Release(projectile);
        }
    }
}