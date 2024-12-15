using Cinemachine;
using Codebase.Logic.Factories;
using Codebase.Logic.Gameplay;
using Codebase.Logic.Gameplay.Camera;
using Codebase.Logic.Gameplay.Characters.Implementations.Gunner;
using Codebase.Logic.Gameplay.Characters.Implementations.Zombie;
using Codebase.Logic.Gameplay.Loot;
using Codebase.Logic.Gameplay.Screens;
using Codebase.Logic.Gameplay.Shooting;
using Codebase.Logic.Gameplay.Spawn;
using Codebase.Logic.Gameplay.Tags;
using Codebase.Logic.Input;
using UnityEngine;
using Zenject;

namespace Codebase.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [Header("Entities Prefabs")]
        [SerializeField] private GunnerBehaviour _gunnerPrefab;
        [SerializeField] private ProjectileBehaviour _projectilePrefab;
        [SerializeField] private ZombieBehaviour[] _zombiePrefabs;

        [Header("UI Prefabs")]
        [SerializeField] private GameOverScreen _gameOverScreenPrefab;
        
        [Header("Scene objects")]
        [SerializeField] private GameplayCameraBehaviour _camera;
        [SerializeField] private GunnerSpawnPointTag _gunnerSpawnPoint;
        
        public override void InstallBindings()
        {
            Container.Bind<IPlayerInput>().To<StandardPlayerInput>().AsTransient();
            
            Container.Bind<CharacterFactory>().AsTransient();
            Container.Bind<GunnerSpawnPointTag>().FromInstance(_gunnerSpawnPoint).AsSingle();

            Container.Bind<GameplayResources>().FromInstance(new GameplayResources(_gunnerPrefab, _projectilePrefab, _zombiePrefabs)).AsSingle();
            Container.Bind<GameplayCameraBehaviour>().FromInstance(_camera).AsSingle();
            
            Container.BindInterfacesAndSelfTo<ShootingSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<LootSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<AmmoSystem>().FromInstance(new AmmoSystem(50)).AsSingle();
            Container.BindInterfacesAndSelfTo<EnemySpawnSystem>().AsSingle();
            
            Container.Bind<ProjectileFactory>().AsTransient();
            Container.Bind<LootFactory>().AsTransient();
            Container.Bind<GunnerBehaviour>().FromResolveGetter<CharacterFactory>(factory => factory.CreateGunner()).AsSingle();

            Container.Bind<GameOverScreen>().FromComponentInNewPrefab(_gameOverScreenPrefab).AsSingle().OnInstantiated<GameOverScreen>((_, obj) => obj.gameObject.SetActive(false)).NonLazy();
            Container.BindInterfacesAndSelfTo<GameLoop>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameStateObserver>().AsSingle();
        }
    }
}