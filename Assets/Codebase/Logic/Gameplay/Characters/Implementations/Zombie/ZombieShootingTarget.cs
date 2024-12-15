using System;
using Codebase.Logic.Gameplay.Shooting;

namespace Codebase.Logic.Gameplay.Characters.Implementations.Zombie
{
    public sealed class ZombieShootingTarget : ShootingTarget
    {
        public event Action Shot;

        public override void OnShot() => Shot?.Invoke();
    }
}