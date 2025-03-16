using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class VerticalSpeedValueText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _verticalSpeedText;
    private IBasePlayerController _playerController;

    public void Initialize(IBasePlayerController abstractPlayerController)
    {
        _playerController = abstractPlayerController;
    }

    private void Update()
    {
        if (_playerController != null)
        {
            VerticalSpeedText();

        }
    }
    private void VerticalSpeedText()
    {
        float verticalSpeed = Vector2.Dot(_playerController.PlayerVelocity, Vector2.down);
        _verticalSpeedText.text = $"VERTICAL SPEED: {verticalSpeed:0.0}";
    }
}
