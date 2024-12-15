using System;
using Codebase.Logic.Gameplay.Screens.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Logic.Gameplay.Screens.Implementation
{
    public class GameOverScreen : MonoBehaviour, IGameOverScreen
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;

        public event Action RestartClicked;
        public event Action ExitClicked;
        
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);

        private void Awake()
        {
            _restartButton.onClick.AddListener(OnRestartClick);
            _exitButton.onClick.AddListener(OnExitClick);
        }

        private void OnRestartClick() => RestartClicked?.Invoke();
        private void OnExitClick() => ExitClicked?.Invoke();
    }
}