using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelAlertObject : MonoBehaviour
{
    private bool _isAlert;
    private float _currentTime;
    [SerializeField] private GameObject _fuelAlertPanel;
    private void Start()
    {
        UiManager.Instance.FuelAlertUİ += HandleOnFuelAlert;
        UpdateFuelAlertPanelActivity(false);

    }
    private void OnDisable()
    {
        UiManager.Instance.FuelAlertUİ -= HandleOnFuelAlert;

    }
    private void LateUpdate()
    {
        if (_isAlert && (_currentTime += Time.deltaTime) > 2)
        {
            UpdateFuelAlertPanelActivity(_currentTime <= 4);
            _currentTime %= 4;
        }
        else
        {
            UpdateFuelAlertPanelActivity(false);
        }
    }

    private void HandleOnFuelAlert(bool canTrue)
    {
        _isAlert = canTrue;
    }
    private void UpdateFuelAlertPanelActivity(bool canActive)
    {
        _fuelAlertPanel.gameObject.SetActive(canActive);
    }
}
