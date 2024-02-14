using TMPro;
using UnityEngine;

public class AltitudeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _altitudeText;
    [SerializeField] private LayerMask _groundLayer;
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }
    private void LateUpdate()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(_playerController.transform.position, -_playerController.transform.up, 1000, _groundLayer);
        if (raycastHit2D.collider != null)
        {
            _altitudeText.text = $"ALTITUDE {(float)Vector3.Distance(raycastHit2D.point, _playerController.transform.position) * 100}";
        }
    }


}
