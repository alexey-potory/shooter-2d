using Codebase.Logic.Gameplay.Loot;
using Zenject;

namespace Codebase.Logic.Factories
{
    public class LootFactory
    {
        private readonly DiContainer _container;

        public LootFactory(DiContainer container)
        {
            _container = container;
        }

        public LootBehaviour Create(LootBehaviour prefab) =>
            _container.InstantiatePrefabForComponent<LootBehaviour>(prefab);
    }
}