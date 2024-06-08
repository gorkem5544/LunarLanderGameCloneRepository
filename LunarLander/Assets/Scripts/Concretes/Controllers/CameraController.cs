using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Camera _mapCamera;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _closeZoom = 1f;
    [SerializeField] private float _zoomSpeed = 5f;
    [SerializeField] private float _groundDistance = 150f;

    private DistanceCalculator _distanceCalculator;

    private void Awake()
    {
        _distanceCalculator = new DistanceCalculator(_playerTransform, _groundLayer);
        SetActiveCamera(_mapCamera, true);
        SetActiveCamera(_playerCamera, false);
    }

    private void Update()
    {
        float distanceToGround = _distanceCalculator.CalculateDistanceToGround() * 100;
        if (distanceToGround < 0) return;

        if (distanceToGround < _groundDistance)
        {
            SetActiveCamera(_playerCamera, true);
            SetActiveCamera(_mapCamera, false);
            AdjustMainCamera();
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

    private void AdjustMainCamera()
    {
        Vector3 targetPosition = _playerTransform.position;
        targetPosition.z = -10;
        _playerCamera.transform.position = Vector3.Lerp(_playerCamera.transform.position, targetPosition, Time.deltaTime * _zoomSpeed);
        _playerCamera.orthographicSize = _closeZoom;
    }
}
