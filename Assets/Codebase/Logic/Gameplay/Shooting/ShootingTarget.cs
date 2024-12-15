using UnityEngine;

namespace Codebase.Logic.Gameplay.Shooting
{
    public abstract class ShootingTarget : MonoBehaviour
    {
        public abstract void OnShot();
    }
}