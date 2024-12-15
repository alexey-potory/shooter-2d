using Codebase.Logic.Factories;
using Codebase.Logic.Gameplay.Camera;
using Codebase.Logic.Gameplay.Characters.Implementations.Gunner;
using Codebase.Logic.Gameplay.Characters.Implementations.Zombie;
using Codebase.Logic.Gameplay.Screens;
using Codebase.Logic.Gameplay.Spawn;
using Codebase.Logic.States.GameStates;
using UnityEngine;
using Zenject;

namespace Codebase.Logic.Gameplay
{
    public class GameLoop : IInitializable
    {
        private readonly CharacterFactory _characterFactory;
        private readonly GameplayCameraBehaviour _camera;
        private readonly EnemySpawnSystem _enemySpawnSystem;
        private readonly GameStateObserver _observer;
        private readonly GameOverScreen _gameOverScreen;
        private readonly GameStateMachine _stateMachine;
        private readonly GunnerBehaviour _gunner;

        public GameLoop(GunnerBehaviour gunner, GameplayCameraBehaviour camera, 
            EnemySpawnSystem enemySpawnSystem, GameStateObserver observer, 
            GameOverScreen gameOverScreen, GameStateMachine stateMachine)
        {
            _gunner = gunner;
            _camera = camera;
            _enemySpawnSystem = enemySpawnSystem;
            _observer = observer;
            _gameOverScreen = gameOverScreen;
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            _camera.SetFollow(_gunner.transform);

            _enemySpawnSystem.EnemySpawned += OnEnemySpawned;
            _enemySpawnSystem.SetState(EnemySpawnSystem.State.Spawning);

            _observer.GameOver += OnGameOver;
            
            _gameOverScreen.RestartClicked += OnRestart;
            _gameOverScreen.ExitClicked += OnExit;
        }

        private void OnGameOver() => 
            _gameOverScreen.gameObject.SetActive(true);

        private void OnEnemySpawned(ZombieBehaviour enemy)
        {
            var followingComponent = enemy.GetComponent<ZombieFollowing>();
            
            if (followingComponent)
                followingComponent.SetTarget(_gunner.transform);
        }

        private void OnRestart() => 
            _stateMachine.Enter<GameplayState>();

        private static void OnExit() => 
            Application.Quit();
    }
}