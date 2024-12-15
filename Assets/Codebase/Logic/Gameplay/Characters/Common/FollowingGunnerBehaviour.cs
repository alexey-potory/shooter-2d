using UnityEngine;
using UnityEngine.Serialization;

namespace Codebase.Logic.Gameplay.Characters.Common
{
    public class FollowingGunnerBehaviour : MonoBehaviour
    {
        [FormerlySerializedAs("_movement")] [SerializeField] private CharacterMovementBehaviour _movementBehaviour;
        
        private Transform _target;

        public void SetTarget(Transform target) => 
            _target = target;
        
        private void Update()
        {
            if (!_target)
                return;
            
            var direction = (_target.position - transform.position).x;
            _movementBehaviour.SetDirection(direction);
        }
    }
}