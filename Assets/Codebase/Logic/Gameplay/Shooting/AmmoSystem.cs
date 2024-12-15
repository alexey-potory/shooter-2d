using System;
using UnityEngine;

namespace Codebase.Logic.Gameplay.Shooting
{
    public class AmmoSystem
    {
        private readonly int _maxAmmo;
        private int _currentAmmo;

        public int CurrentAmmo
        {
            get => _currentAmmo;
            set
            {
                _currentAmmo = Mathf.Clamp(value, 0, _maxAmmo);
                CountChanged?.Invoke(_currentAmmo);
            }
        }

        public event Action<int> CountChanged;
        
        public AmmoSystem(int maxAmmo)
        {
            _maxAmmo = maxAmmo;
            _currentAmmo = maxAmmo;
        }
    }
}