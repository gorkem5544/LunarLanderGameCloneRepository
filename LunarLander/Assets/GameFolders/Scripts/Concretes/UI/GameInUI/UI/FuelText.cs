using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Abstracts;
using TMPro;
using UnityEngine;

public class FuelText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private IPlayerController _playerController;
    public void Initialize(IPlayerController playerController)
    {
        _playerController = playerController;
    }
    private void LateUpdate()
    {

        UpdateFuelText();

    }
    private void UpdateFuelText()
    {
        _text.text = $"FUEL: {_playerController.FuelController.CurrentFuel:0.0}";
    }
}
