using UnityEngine;

namespace Codebase.Logic.Input
{
    public class StandardPlayerInput : IPlayerInput
    {
        public float? MovementDirection => GetMovementDirection();
        public bool IsSingleShot => UnityEngine.Input.GetMouseButtonDown(0);
        public bool IsBursting => UnityEngine.Input.GetMouseButton(1);

        private static float? GetMovementDirection()
        {
            float? movementDirection = null;
            
            if (UnityEngine.Input.GetKey(KeyCode.D))
                movementDirection =+ 1;

            if (UnityEngine.Input.GetKey(KeyCode.A))
                movementDirection =+ -1;

            return movementDirection;
        }
    }
}