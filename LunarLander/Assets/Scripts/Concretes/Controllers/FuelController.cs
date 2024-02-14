using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FuelController
{
    private float _maxFuel;
    private float _currentFuel;
    public bool IsEmpty => _currentFuel < 1f;
    public float CurrentFuel => _currentFuel;

    public FuelController(float maxFuel)
    {
        _maxFuel = maxFuel;
    }
    public void StartTick()
    {
        _currentFuel = _maxFuel;
    }

    public void FuelDecrease(float decrease)
    {
        _currentFuel -= decrease;
        _currentFuel = Mathf.Max(_currentFuel, 0f);

        // if (_particle.isStopped)
        // {
        //     _particle.Play();
        // }

        // SoundManager.Instance.PlaySound(0);
    }
}
