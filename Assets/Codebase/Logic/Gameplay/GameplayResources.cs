using Codebase.Logic.Gameplay.Characters.Implementations;
using Codebase.Logic.Gameplay.Characters.Implementations.Gunner;
using Codebase.Logic.Gameplay.Characters.Implementations.Zombie;
using Codebase.Logic.Gameplay.Loot;
using Codebase.Logic.Gameplay.Shooting;

namespace Codebase.Logic.Gameplay
{
    public class GameplayResources
    {
        public GunnerBehaviour GunnerPrefab { get; }
        public ZombieBehaviour[] ZombiePrefabs { get; }
        public ProjectileBehaviour ProjectilePrefab { get; }

        public GameplayResources(GunnerBehaviour gunnerPrefab, ProjectileBehaviour projectilePrefab, ZombieBehaviour[] zombiePrefabs)
        {
            GunnerPrefab = gunnerPrefab;
            ProjectilePrefab = projectilePrefab;
            ZombiePrefabs = zombiePrefabs;
        }
    }
}