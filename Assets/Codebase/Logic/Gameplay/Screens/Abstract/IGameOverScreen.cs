using System;

namespace Codebase.Logic.Gameplay.Screens.Abstract
{
    public interface IGameOverScreen
    {
        event Action RestartClicked;
        event Action ExitClicked;

        public void Show();
        public void Hide();
    }
}