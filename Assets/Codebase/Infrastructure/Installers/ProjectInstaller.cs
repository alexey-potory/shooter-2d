using Codebase.Infrastructure.Abstract;
using Codebase.Infrastructure.Implementation;
using Codebase.Logic.Factories;
using Codebase.Logic.States.GameStates;
using UnityEngine;
using Zenject;

namespace Codebase.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromNewComponentOn(gameObject).AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsTransient();
            Container.Bind<ILoadingScreen>().To<LoadingScreen>().FromComponentInNewPrefab(_loadingScreen).AsSingle().NonLazy();
            Container.Bind<IAssetsProvider>().To<ResourcesAssetsProvider>().AsTransient();
            Container.Bind<GameStateFactory>().AsTransient();
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle().NonLazy();
        }
    }
}
