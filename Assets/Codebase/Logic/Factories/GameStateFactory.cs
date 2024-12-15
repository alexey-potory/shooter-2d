using Codebase.Logic.States.Abstraction;
using Zenject;

namespace Codebase.Logic.Factories
{
    public class GameStateFactory
    {
        private readonly DiContainer _container;

        public GameStateFactory(DiContainer container) => 
            _container = container;

        public IExitableState CreateState<TState>() where TState : class, IExitableState => 
            _container.Instantiate<TState>();
    }
}