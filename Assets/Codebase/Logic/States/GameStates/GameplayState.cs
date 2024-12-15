using Codebase.Infrastructure.Abstract;
using Codebase.Logic.States.Abstraction;

namespace Codebase.Logic.States.GameStates
{
    public class GameplayState : IState
    {
        private const string GameplayScenePath = "Scenes/GameplayScene";
        
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingScreen _loadingScreen;
        private readonly GameStateMachine _stateMachine;

        public GameplayState(ISceneLoader sceneLoader, ILoadingScreen loadingScreen, GameStateMachine stateMachine)
        {
            _sceneLoader = sceneLoader;
            _loadingScreen = loadingScreen;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _loadingScreen.Show();
            _sceneLoader.Load(GameplayScenePath, true, OnSceneLoaded);
        }

        private void OnSceneLoaded()
        {
            _loadingScreen.Hide();
        }

        public void Exit() {}
    }
}