using Codebase.Logic.Gameplay.Characters.Implementations.Zombie;
using UnityEngine;
using Zenject;

namespace Codebase.Logic.Gameplay.Loot.Drop
{
    [RequireComponent(typeof(ZombieBehaviour))]
    public class DropLootOnKilledBehaviour : MonoBehaviour
    {
        [SerializeField] private LootBehaviour _lootPrefab;

        private ZombieBehaviour _zombieBehaviour;
        private LootSystem _lootSystem;

        [Inject]
        public void Construct(LootSystem lootSystem) => 
            _lootSystem = lootSystem;

        private void Awake()
        {
            _zombieBehaviour = GetComponent<ZombieBehaviour>();
            _zombieBehaviour.Killed += OnEnemyKilled;
        }

        private void OnDestroy() => 
            _zombieBehaviour.Killed -= OnEnemyKilled;

        private void OnEnemyKilled(ZombieBehaviour enemy)
        {
            var loot = _lootSystem.CreateLoot(_lootPrefab);
            
            loot.transform.position = enemy.transform.position + Vector3.up;
            loot.transform.rotation = Quaternion.identity;
        }
    }
}