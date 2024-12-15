using Codebase.Logic.Gameplay;
using Codebase.Logic.Gameplay.Characters.Implementations.Gunner;
using Codebase.Logic.Gameplay.Characters.Implementations.Zombie;
using Codebase.Logic.Gameplay.Tags;
using UnityEngine;
using Zenject;

namespace Codebase.Logic.Factories
{
    public class CharacterFactory
    {
        private readonly DiContainer _container;

        public CharacterFactory(DiContainer container) => 
            _container = container;

        public GunnerBehaviour CreateGunner()
        {
            var gameplayResources = _container.Resolve<GameplayResources>();
            var spawnPoint = _container.Resolve<GunnerSpawnPointTag>();
            
            var gunner = _container.InstantiatePrefabForComponent<GunnerBehaviour>(gameplayResources.GunnerPrefab);
            gunner.transform.position = spawnPoint.transform.position;

            return gunner;
        }

        public ZombieBehaviour CreateZombie()
        {
            var gameplayResources = _container.Resolve<GameplayResources>();
            var index = Random.Range(0, gameplayResources.ZombiePrefabs.Length);
            
            var zombie = _container.InstantiatePrefabForComponent<ZombieBehaviour>(gameplayResources.ZombiePrefabs[index]);
            
            return zombie;
        }
    }
}