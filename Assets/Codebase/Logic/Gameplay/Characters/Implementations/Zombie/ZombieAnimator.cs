using System;
using Codebase.Logic.Gameplay.Characters.Abstract.Zombie;
using UnityEngine;

namespace Codebase.Logic.Gameplay.Characters.Implementations.Zombie
{
    public class ZombieAnimator : MonoBehaviour, IZombieAnimator
    {
        [SerializeField] private Animator _characterAnimator;
        
        private readonly int _walkingAnimationHash = Animator.StringToHash("Walking");
        
        public void SetAnimation(ZombieAnimation anim)
        {
            switch (anim)
            {
                case ZombieAnimation.Walking:
                    _characterAnimator.Play(_walkingAnimationHash);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(anim), anim, null);
            }
        }
    }
}