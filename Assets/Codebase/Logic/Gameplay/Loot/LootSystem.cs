using Codebase.Logic.Factories;

namespace Codebase.Logic.Gameplay.Loot
{
    public class LootSystem
    {
        private readonly LootFactory _factory;

        public LootSystem(LootFactory factory)
        {
            _factory = factory;
        }

        public LootBehaviour CreateLoot(LootBehaviour prefab)
        {
            var loot = _factory.Create(prefab);
            return loot;
        }
    }
}