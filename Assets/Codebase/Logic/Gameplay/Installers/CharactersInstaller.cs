using Codebase.Logic.Factories;
using Codebase.Logic.Gameplay.Characters.Implementations.Gunner;
using Codebase.Logic.Gameplay.Spawn;
using Codebase.Logic.Gameplay.Tags;
using UnityEngine;
using Zenject;

namespace Codebase.Logic.Gameplay.Installers
{
    public class CharactersInstaller : MonoInstaller
    {
        [SerializeField] private GunnerSpawnPointTag _gunnerSpawnPoint;
        
        public override void InstallBindings()
        {
            Container.Bind<GunnerBehaviour>().FromResolveGetter<CharacterFactory>(factory => factory.CreateGunner()).AsSingle();
            Container.Bind<CharacterFactory>().AsTransient();
            Container.Bind<GunnerSpawnPointTag>().FromInstance(_gunnerSpawnPoint).AsSingle();
            Container.BindInterfacesAndSelfTo<EnemySpawnSystem>().AsSingle();
        }
    }
}