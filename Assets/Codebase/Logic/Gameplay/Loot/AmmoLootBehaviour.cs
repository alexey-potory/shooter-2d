using System;
using Codebase.Logic.Gameplay.Shooting;
using TMPro;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Codebase.Logic.Gameplay.Loot
{
    public sealed class AmmoLootBehaviour : LootBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;

        private int _count;
        private AmmoSystem _ammoSystem;

        private void Awake()
        {
            _count = Random.Range(5, 10);
            _label.text = _count.ToString();
        }

        [Inject]
        public void Construct(AmmoSystem ammoSystem) => 
            _ammoSystem = ammoSystem;

        protected override void OnLootPicked() => 
            _ammoSystem.CurrentAmmo += _count;
    }
}