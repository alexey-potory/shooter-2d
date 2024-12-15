using Cinemachine;
using Codebase.Logic.Gameplay.Camera.Abstract;
using Codebase.Logic.Gameplay.Characters.Implementations.Gunner;
using UnityEngine;
using Zenject;

namespace Codebase.Logic.Gameplay.Camera.Implementation
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class GameplayCameraHandlerBehaviour : MonoBehaviour, IGameplayCameraHandler
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private UnityEngine.Camera _realCamera;
        
        private GunnerBehaviour _gunner;

        public Bounds? Bounds { get; private set; }

        [Inject]
        public void Construct(GunnerBehaviour gunner)
        {
            _gunner = gunner;
        }

        private void Start()
        {
            _virtualCamera.Follow = _gunner.transform;
        }

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