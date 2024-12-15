using System;
using Codebase.Logic.Gameplay.Shooting.Abstract;
using UnityEngine;

namespace Codebase.Logic.Gameplay.Shooting
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        public float Direction { get; private set; }
        public float Speed { get; private set; }

        public event Action<ProjectileBehaviour, IShootingTarget> HitTarget;

        public void SetDirection(float direction) => 
            Direction = Mathf.Sign(direction);

        public void SetSpeed(float speed) => 
            Speed = Mathf.Abs(speed);

        private void OnTriggerEnter2D(Collider2D other)
        {
            var target = other.GetComponent<IShootingTarget>();
            
            if (!(target as MonoBehaviour))
                return;
            
            HitTarget?.Invoke(this, target);
        }
    }
}