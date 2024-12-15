using System;
using Cinemachine;
using UnityEngine;

namespace Codebase.Logic.Gameplay.Camera
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class GameplayCameraBehaviour : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private UnityEngine.Camera _realCamera;

        public void SetFollow(Transform target) => 
            _virtualCamera.Follow = target;

        public Bounds? Bounds { get; private set; }

        private void Update()
        {
            var min = _realCamera.ViewportToWorldPoint(new Vector3(0, 0));
            var max = _realCamera.ViewportToWorldPoint(new Vector3(1, 1));

            var width = max.x - min.x;
            var height = max.y - min.y;

            var centerX = min.x + width / 2;
            var centerY = min.y + height / 2;

            Bounds = new Bounds(new Vector3(centerX, centerY, 0), new Vector3(width, height, 1));
        }

        private void OnValidate() => 
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
}