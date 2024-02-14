using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
enum HorizontalSpeedInfoImageEnum
{
    Left, Right
}
public class HorizontalSpeedText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _horizontalSpeedText;
    private PlayerController _playerController;
    [SerializeField] private Image _horizontalSpeedInfoImage;

    Vector3 eulerAngles;
    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }
    private void Start()
    {
        eulerAngles = _horizontalSpeedInfoImage.transform.eulerAngles;
    }
    private void Update()
    {
        if (_playerController.PlayerVelocity().x >= 0)
        {
            _horizontalSpeedInfoImage.transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, 90);
        }
        else
        {
            _horizontalSpeedInfoImage.transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, -90);
        }
    }
    private void LateUpdate()
    {
        _horizontalSpeedText.text = $"HORIZONTAL SPEED {_playerController.PlayerVelocity().x.ToString("0.0")}";
    }
}
