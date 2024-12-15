using System;
using Codebase.Logic.Factories;
using Codebase.Logic.Gameplay.Camera;
using Codebase.Logic.Gameplay.Characters.Implementations.Zombie;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Codebase.Logic.Gameplay.Spawn
{
    public class EnemySpawnSystem : ITickable
    {    
        public enum State
        {
            Waiting,
            Spawning
        };
        
        private readonly CharacterFactory _factory;
        private readonly GameplayCameraBehaviour _cameraBehaviour;

        private Transform _enemyParent = new GameObject("Enemies").transform;
        
        private const float OffscreenSpawnOffset = 0.5f;

        private float _timeout;
        private bool _isInitialized;

        public event Action<ZombieBehaviour> EnemySpawned;
        
        public State CurrentState { get; private set; } = State.Waiting;

        public EnemySpawnSystem(CharacterFactory factory, GameplayCameraBehaviour cameraBehaviour)
        {
            _factory = factory;
            _cameraBehaviour = cameraBehaviour;
        }

        public void SetState(State currentState) => CurrentState = currentState;

        public void Tick()
        {
            if (CurrentState != State.Spawning)
                return;
            
            if (Mathf.Abs(_timeout) > Mathf.Epsilon)
            {
                _timeout -= Time.deltaTime;

                if (_timeout < 0)
                    _timeout = 0;
                
                return;
            }
            
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            var bounds = _cameraBehaviour.Bounds;
            
            if (!bounds.HasValue)
                return;

            var zombie = CreateEnemy();
            
            var center = bounds.Value.center;
            var halfSize = bounds.Value.size / 2;

            var isRightSide = Random.Range(0, 2) > 0;

            const float startingY = .5f;
            
            zombie.transform.position = isRightSide ? 
                new Vector2(center.x + halfSize.x + OffscreenSpawnOffset, startingY) : 
                new Vector2(center.x - halfSize.x - OffscreenSpawnOffset, startingY);
            
            SetTimeout();
            
            EnemySpawned?.Invoke(zombie);
        }

        private ZombieBehaviour CreateEnemy()
        {
            var enemy = _factory.CreateZombie();
            enemy.transform.SetParent(_enemyParent);
            enemy.Killed += OnEnemyKilled;
            
            return enemy;
        }

        private static void OnEnemyKilled(ZombieBehaviour enemy)
        {
            enemy.Killed -= OnEnemyKilled;
            Object.Destroy(enemy.gameObject); 
        }

        private void SetTimeout() => _timeout = Random.Range(1f, 10f);
    }
}