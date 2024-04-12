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
        RaycastHit2D raycastHit2D = Physics2D.Raycast(_playerController.transform.position, -_playerController.transform.up, 1000, _groundLayer);
        if (raycastHit2D.collider != null)
        {
            _altitudeDisplayText.text = $"ALTITUDE {((float)Vector3.Distance(raycastHit2D.point, _playerController.transform.position) * 100).ToString("0.0")}";
        }
    }


}
