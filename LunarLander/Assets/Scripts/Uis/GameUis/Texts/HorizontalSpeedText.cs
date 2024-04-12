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
    private AbstractPlayerController _playerController;
    [SerializeField] private Image _horizontalSpeedInfoImage;

    Vector3 eulerAngles;
    private void Awake()
    {
        _playerController = FindObjectOfType<AbstractPlayerController>();
    }
    private void Start()
    {
        eulerAngles = _horizontalSpeedInfoImage.transform.eulerAngles;
    }
    private void Update()
    {
        float rotationAngle = (_playerController.PlayerVelocity().x >= 0) ? 90f : -90f;
        _horizontalSpeedInfoImage.transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, rotationAngle);

    }
    private void LateUpdate()
    {
        _horizontalSpeedText.text = "HORIZONTAL SPEED: " + _playerController.GetComponent<Rigidbody2D>().velocity.magnitude.ToString("0.0");
    }
}
