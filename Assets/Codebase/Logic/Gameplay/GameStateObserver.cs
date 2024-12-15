using System;
using Codebase.Logic.Gameplay.Characters.Implementations.Gunner;
using Codebase.Logic.Gameplay.Shooting;

namespace Codebase.Logic.Gameplay
{
    public class GameStateObserver
    {
        private readonly AmmoSystem _ammoSystem;
        private readonly GunnerBehaviour _gunnerBehaviour;

        public event Action GameOver;
        
        public GameStateObserver(AmmoSystem ammoSystem, GunnerBehaviour gunnerBehaviour)
        {
            _ammoSystem = ammoSystem;
            _gunnerBehaviour = gunnerBehaviour;

            _ammoSystem.CountChanged += OnAmmoChanged;
            _gunnerBehaviour.EnemyTouched += OnGunnerTouchedEnemy;

            GameOver += OnGameOver;
        }

        private void OnAmmoChanged(int count)
        {
            if (count > 0)
                return;
            
            GameOver?.Invoke();
        }

        private void OnGunnerTouchedEnemy() => GameOver?.Invoke();

        private void OnGameOver()
        {
            _ammoSystem.CountChanged -= OnAmmoChanged;
            _gunnerBehaviour.EnemyTouched -= OnGunnerTouchedEnemy;
        }
    }
}