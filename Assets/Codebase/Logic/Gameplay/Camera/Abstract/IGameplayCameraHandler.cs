using UnityEngine;

namespace Codebase.Logic.Gameplay.Camera.Abstract
{
    public interface IGameplayCameraHandler
    {
        Bounds? Bounds { get; }
    }
}