using Codebase.Logic.Gameplay.Characters.Implementations.Gunner;
using Codebase.Logic.Gameplay.Characters.Implementations.Zombie;
using Codebase.Logic.Gameplay.Shooting;
using UnityEngine;
using Zenject;

namespace Codebase.Logic.Gameplay.Installers
{
    /// <summary>
    /// Mock installer for imitate resource passing from previous logic
    /// </summary>
    public class GameplayResourcesInstallers : MonoInstaller
    {
        [SerializeField] private GunnerBehaviour _gunnerPrefab;
        [SerializeField] private ProjectileBehaviour _projectilePrefab;
        [SerializeField] private ZombieBehaviour[] _zombiePrefabs;
        
        public override void InstallBindings()
        {
            var gameplayResources = new GameplayResources(
                _gunnerPrefab, 
                _projectilePrefab, 
                _zombiePrefabs);
            
            Container.Bind<GameplayResources>()
                .FromInstance(gameplayResources)
                .AsSingle();
        }
    }
}