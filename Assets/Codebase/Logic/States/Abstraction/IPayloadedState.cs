namespace Codebase.Logic.States.Abstraction
{
    public interface IPayloadedState<in T> : IExitableState
    {
        void Enter(T payload);
    }
}