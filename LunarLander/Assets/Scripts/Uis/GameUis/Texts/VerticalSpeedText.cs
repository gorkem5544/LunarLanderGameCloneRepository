using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class VerticalSpeedText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _verticalSpeedText;
    [SerializeField] private Image _verticalSpeedInfoImage;
    private PlayerController _playerController;
    Vector3 eulerAngles;
    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }
    private void Start()
    {
        eulerAngles = _verticalSpeedInfoImage.transform.eulerAngles;
    }
    private void Update()
    {
        if (_playerController.PlayerVelocity().y >= 0)
        {
            _verticalSpeedInfoImage.transform.rotation = Quaternion.Euler(180, eulerAngles.y, eulerAngles.z);
        }
        else
        {
            _verticalSpeedInfoImage.transform.rotation = Quaternion.Euler(0, eulerAngles.y, eulerAngles.z);
        }
    }
    private void LateUpdate()
    {
        _verticalSpeedText.text = $"VERTICAL SPEED {_playerController.PlayerVelocity().y.ToString("0.0")}";
    }
}
