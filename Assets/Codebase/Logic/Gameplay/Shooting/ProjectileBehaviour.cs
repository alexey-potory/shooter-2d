using System;
using UnityEngine;

namespace Codebase.Logic.Gameplay.Shooting
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        public float Direction { get; private set; }
        public float Speed { get; private set; }

        public event Action<ProjectileBehaviour, ShootingTarget> HitTarget;

        public void SetDirection(float direction) => 
            Direction = Mathf.Sign(direction);

        public void SetSpeed(float speed) => 
            Speed = Mathf.Abs(speed);

        private void OnTriggerEnter2D(Collider2D other)
        {
            var target = other.GetComponent<ShootingTarget>();
            
            if (!target)
                return;
            
            HitTarget?.Invoke(this, target);
        }
    }
}