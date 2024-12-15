using UnityEngine;

namespace Codebase.Logic.Gameplay.Characters.Implementations.Zombie
{
    public class ZombieFollowing : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;
        
        private Transform _target;

        public void SetTarget(Transform target) => 
            _target = target;
        
        private void Update()
        {
            if (!_target)
                return;
            
            var direction = (_target.position - transform.position).x;
            _movement.SetDirection(direction);
        }
    }
}