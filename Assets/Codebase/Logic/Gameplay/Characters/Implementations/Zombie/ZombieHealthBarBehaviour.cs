using UnityEngine;

namespace Codebase.Logic.Gameplay.Characters.Implementations.Zombie
{
    public class ZombieHealthBarBehaviour : MonoBehaviour
    {
        [SerializeField] private RectTransform _healthBarRect;

        private void Update() => 
            transform.rotation = Quaternion.identity;

        public void SetValue(float value) => 
            _healthBarRect.localScale = new Vector2(value, 1);
    }
}