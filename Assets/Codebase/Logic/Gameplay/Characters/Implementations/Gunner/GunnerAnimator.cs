using System;
using Codebase.Logic.Gameplay.Characters.Abstract.Gunner;
using UnityEngine;

namespace Codebase.Logic.Gameplay.Characters.Implementations.Gunner
{
    public class GunnerAnimator : MonoBehaviour, IGunnerAnimator
    {
        [SerializeField] private Animator _characterAnimator;
        
        private readonly int _idleAnimationHash = Animator.StringToHash("Idle");
        private readonly int _runningAnimationHash = Animator.StringToHash("Running");
        private readonly int _shootingAnimationHash = Animator.StringToHash("Shooting");

        public void SetAnimation(GunnerAnimation anim)
        {
            switch (anim)
            {
                case GunnerAnimation.Idle:
                    _characterAnimator.Play(_idleAnimationHash);
                    break;
                case GunnerAnimation.Running:
                    _characterAnimator.Play(_runningAnimationHash);
                    break;
                case GunnerAnimation.Shooting:
                    _characterAnimator.Play(_shootingAnimationHash);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(anim), anim, null);
            }
        }
    }
}