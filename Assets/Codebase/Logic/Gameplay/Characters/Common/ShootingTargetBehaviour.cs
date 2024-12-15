using System;
using Codebase.Logic.Gameplay.Shooting.Abstract;
using UnityEngine;

namespace Codebase.Logic.Gameplay.Characters.Common
{
    public sealed class ShootingTargetBehaviour : MonoBehaviour, IShootingTarget
    {
        public event Action Shot;

        public void OnShot() => Shot?.Invoke();
    }
}