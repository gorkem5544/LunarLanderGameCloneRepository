using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerFuel
{

    public float GameStartingFuel { get; set; }
    private float _currentFuel;
    public bool IsEmpty => _currentFuel < 1f;
    public float CurrentFuel => _currentFuel;
    public bool IsFuelAlert => _currentFuel < 100;

    public void UpdateGameStartingFuel(float fuelValue)
    {
        GameStartingFuel = fuelValue;
        _currentFuel = fuelValue;
        Debug.Log(_currentFuel);
    }

    public void FuelDecrease(float decrease)
    {
        _currentFuel -= decrease;
        _currentFuel = Mathf.Max(_currentFuel, 0f);
        if (IsFuelAlert)
        {
            UiManager.Instance.FuelAlertUİ?.Invoke(IsFuelAlert);
        }
    }

}
