using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes;
using Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Concretes;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.CameraScripts.Concretes
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private Camera _mapCamera;
        private Transform _playerTransform;
        [SerializeField] private CameraScriptableObject _cameraScripTableObject;

        private IDistanceCalculator _distanceCalculator;
        private float _playerDistanceGround;

        private void Awake()
        {
            SetActiveCamera(_mapCamera, true);
            SetActiveCamera(_playerCamera, false);
        }
        public void Initialize(IBasePlayerController abstractPlayerController)
        {
            _playerTransform = abstractPlayerController.transform;
            _distanceCalculator = new DistanceCalculator(abstractPlayerController.transform, _cameraScripTableObject.GroundLayer);
        }
        private void Update()
        {
            _playerDistanceGround = _distanceCalculator.CalculateDistanceToGround();
            if (_playerDistanceGround < 0) return;

            if (_playerDistanceGround < _cameraScripTableObject.GroundDistance)
            {
                SetActiveCamera(_playerCamera, true);
                SetActiveCamera(_mapCamera, false);
                PlayerZoomAndFollow();
            }
            else
            {
                SetActiveCamera(_playerCamera, false);
                SetActiveCamera(_mapCamera, true);
            }
        }

        private void SetActiveCamera(Camera camera, bool isActive)
        {
            camera.enabled = isActive;
        }

        private void PlayerZoomAndFollow()
        {
            Vector3 targetPosition = _playerTransform.position;
            targetPosition.z = -10;
            _playerCamera.transform.position = Vector3.Lerp(_playerCamera.transform.position, targetPosition, Time.deltaTime * _cameraScripTableObject.ZoomSpeed);
            _playerCamera.orthographicSize = _cameraScripTableObject.CloseZoom;
        }
    }

}