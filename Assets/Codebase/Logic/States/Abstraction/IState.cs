namespace Codebase.Logic.States.Abstraction
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}