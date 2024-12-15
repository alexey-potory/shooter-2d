using Codebase.Logic.States.Abstraction;

namespace Codebase.Logic.States.GameStates
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public void Enter()
        {
            _stateMachine.Enter<GameplayState>();
        }
        
        public void Exit() {}
    }
}