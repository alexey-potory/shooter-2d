using Codebase.Logic.Gameplay.Shooting;
using TMPro;
using UnityEngine;
using Zenject;

namespace Codebase.Logic.Gameplay.Displays
{
    public class AmmoCountDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        
        private AmmoSystem _ammoSystem;

        [Inject]
        public void Construct(AmmoSystem ammoSystem)
        {
            _ammoSystem = ammoSystem;
            _ammoSystem.CountChanged += UpdateAmmoCountLabel;

            UpdateAmmoCountLabel(ammoSystem.CurrentAmmo);
        }

        private void UpdateAmmoCountLabel(int count) => 
            _label.text = count.ToString();
    }
}