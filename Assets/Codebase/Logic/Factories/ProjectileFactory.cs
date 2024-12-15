using System;
using Codebase.Logic.Gameplay;
using Codebase.Logic.Gameplay.Shooting;
using Zenject;

namespace Codebase.Logic.Factories
{
    public class ProjectileFactory
    {
        private readonly DiContainer _container;
        private readonly GameplayResources _resources;

        public ProjectileFactory(DiContainer container, GameplayResources resources)
        {
            _container = container;
            _resources = resources;
        }
        
        public ProjectileBehaviour CreateBullet() => 
            _container.InstantiatePrefabForComponent<ProjectileBehaviour>(_resources.ProjectilePrefab);
    }
}