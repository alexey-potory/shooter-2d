using System;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Logic.Gameplay.Screens
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;

        public event Action RestartClicked;
        public event Action ExitClicked;
        
        private void Awake()
        {
            _restartButton.onClick.AddListener(OnRestartClick);
            _exitButton.onClick.AddListener(OnExitClick);
        }

        private void OnRestartClick() => RestartClicked?.Invoke();
        private void OnExitClick() => ExitClicked?.Invoke();
    }
}