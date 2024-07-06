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
        float VerticalSpeed = _playerController.PlayerVelocity.y;
        _verticalSpeedText.text = $"VERTICAL SPEED: {VerticalSpeed:0.0}";
    }
}
