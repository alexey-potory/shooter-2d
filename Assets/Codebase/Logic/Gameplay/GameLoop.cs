using Codebase.Logic.Factories;
using Codebase.Logic.Gameplay.Screens.Abstract;
using Codebase.Logic.Gameplay.Spawn;
using Codebase.Logic.States.GameStates;
using UnityEngine;
using Zenject;

namespace Codebase.Logic.Gameplay
{
    public class GameLoop : IInitializable
    {
        private readonly CharacterFactory _characterFactory;
        private readonly EnemySpawnSystem _enemySpawnSystem;
        private readonly GameStateObserver _observer;
        private readonly IGameOverScreen _gameOverScreen;
        private readonly GameStateMachine _stateMachine;

        public GameLoop(EnemySpawnSystem enemySpawnSystem, GameStateObserver observer, 
            IGameOverScreen gameOverScreen, GameStateMachine stateMachine)
        {
            _enemySpawnSystem = enemySpawnSystem;
            _observer = observer;
            _gameOverScreen = gameOverScreen;
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            _enemySpawnSystem.SetState(EnemySpawnSystem.State.Spawning);

            _observer.GameOver += OnGameOver;
            
            _gameOverScreen.RestartClicked += OnRestart;
            _gameOverScreen.ExitClicked += OnExit;
        }

        private void OnGameOver()
        {
            Time.timeScale = 0;
            _gameOverScreen.Show();
        }

        private void OnRestart()
        {
            Time.timeScale = 1;
            _stateMachine.Enter<GameplayState>();
        }

        private static void OnExit() => 
            Application.Quit();
    }
}