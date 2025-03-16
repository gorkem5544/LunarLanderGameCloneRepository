using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HorizontalSpeedValueText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _horizontalSpeedText;
    private IBasePlayerController _playerController;


    public void Initialize(IBasePlayerController abstractPlayerController)
    {
        _playerController = abstractPlayerController;
    }

    private void Update()
    {
        if (_playerController != null)
        {
            UpdateHorizontalSpeedText();
        }
    }

    private void UpdateHorizontalSpeedText()
    {
        float horizontalSpeed = _playerController.PlayerVelocity.x;
        _horizontalSpeedText.text = $"HORIZONTAL SPEED: {horizontalSpeed:0.0}";
    }
}
