using TMPro;
using UnityEngine;

public class PlayerAltitudeDisplayText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _altitudeDisplayText;
    [SerializeField] private LayerMask _groundLayer;
    private AbstractPlayerController _playerController;

    private void Awake()
    {
        _playerController = FindObjectOfType<AbstractPlayerController>();

    }
    private void LateUpdate()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(_playerController.transform.position, Vector2.down, 1000, _groundLayer);
        Debug.DrawRay(_playerController.transform.position, Vector2.down, Color.blue, 100f);
        if (raycastHit2D.collider != null)
        {
            _altitudeDisplayText.text = $"ALTITUDE {((float)Vector3.Distance(raycastHit2D.point, _playerController.transform.position) * 100).ToString("0.0")}";
        }
    }


}

public class DistanceCalculator
{
    private Transform _playerTransform;
    private LayerMask _groundLayer;

    public DistanceCalculator(Transform playerTransform, LayerMask groundLayer)
    {
        _playerTransform = playerTransform;
        _groundLayer = groundLayer;
    }

    public float CalculateDistanceToGround()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(_playerTransform.position, Vector2.down, 1000, _groundLayer);
        if (raycastHit2D.collider != null)
        {
            return raycastHit2D.distance;
        }
        return -1; // If no ground is detected, return -1 or an appropriate value indicating no ground.
    }
}