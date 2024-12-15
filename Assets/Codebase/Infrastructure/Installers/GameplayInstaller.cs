using Codebase.Logic.Gameplay;
using Codebase.Logic.Gameplay.Camera.Abstract;
using Codebase.Logic.Gameplay.Camera.Implementation;
using Codebase.Logic.Gameplay.Screens.Abstract;
using Codebase.Logic.Gameplay.Screens.Implementation;
using Codebase.Logic.Input;
using UnityEngine;
using Zenject;

namespace Codebase.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [Header("Prefabs")]
        [SerializeField] private GameOverScreen _gameOverScreenPrefab;

        [Header("Scene objects")]
        [SerializeField] private GameplayCameraHandlerBehaviour _cameraHandler;
        [SerializeField] private NewPlayerInput _playerInput;

        public override void InstallBindings()
        {
            Container.Bind<IPlayerInput>().FromInstance(_playerInput).AsSingle();
            Container.Bind<IGameplayCameraHandler>().To<GameplayCameraHandlerBehaviour>().FromInstance(_cameraHandler).AsSingle();
            Container.Bind<IGameOverScreen>().To<GameOverScreen>().FromComponentInNewPrefab(_gameOverScreenPrefab).AsSingle().OnInstantiated<GameOverScreen>((_, obj) => obj.gameObject.SetActive(false)).NonLazy();
            Container.BindInterfacesAndSelfTo<GameLoop>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameStateObserver>().AsSingle();
        }
    }
}