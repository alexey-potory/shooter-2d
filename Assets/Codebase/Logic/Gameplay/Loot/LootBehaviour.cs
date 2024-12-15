using System;
using Codebase.Logic.Gameplay.Characters.Implementations.Gunner;
using UnityEngine;

namespace Codebase.Logic.Gameplay.Loot
{
    public abstract class LootBehaviour : MonoBehaviour
    {
        public event Action<LootBehaviour> Picked; 
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var gunner = other.gameObject.GetComponent<GunnerBehaviour>();
            
            if (!gunner)
                return;

            Picked?.Invoke(this);
            OnLootPicked();
            
            Destroy(gameObject);
        }

        protected abstract void OnLootPicked();
    }
}