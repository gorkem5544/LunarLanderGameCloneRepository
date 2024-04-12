using UnityEngine;

public class FuelText : AbstractTextUi
{
    private PlayerController _playerController;
    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }
    private void LateUpdate()
    {
        UpdateFuelText();
    }
    private void UpdateFuelText()
    {
        _text.text = $"FUEL {_playerController.FuelController.CurrentFuel.ToString("0.0")}";
    }
}
