using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using Unity.Mathematics;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Concretes
{
    public class PlayerFuel : IPlayerFuel
    {

        private float _currentFuel;

        public float gameStartingFuel { get; private set; }
        public bool IsEmpty => _currentFuel <= 1f;
        public float CurrentFuel => _currentFuel;
        public bool IsFuelAlert => _currentFuel < 100;
        public float ShipExplosionDecreaseFuelAmount { get; set; } = 400;

        public event Action<bool> FuelAlert;

        public PlayerFuel(IPlayerFuelService playerFuelService)
        {
            gameStartingFuel = playerFuelService.PlayerFuelSO.GameStartingFuelAmount;
            _currentFuel = gameStartingFuel;
        }

        public void UpdateGameStartingFuel(float fuelValue)
        {
            gameStartingFuel = fuelValue;
            _currentFuel = fuelValue;
        }

        public void DecreaseFuel(float amount)
        {
            _currentFuel -= amount;
            _currentFuel = Mathf.Max(_currentFuel, 0f);
            FuelAlert?.Invoke(IsFuelAlert);

        }

        public void ShipExplosionDecreaseFuel()
        {
            DecreaseFuel(ShipExplosionDecreaseFuelAmount);
        }

    }

}