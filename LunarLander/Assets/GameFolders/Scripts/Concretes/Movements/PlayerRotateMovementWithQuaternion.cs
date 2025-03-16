using System;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Concretes
{
    public class PlayerRotateMovementWithQuaternion : IPlayerRotateMovement
    {
        IPlayerRotationService _playerRotationService;
        private float _rotationInput;
        public PlayerRotateMovementWithQuaternion(IPlayerRotationService playerRotationService)
        {
            _playerRotationService = playerRotationService;
        }

        public void UpdateTick()
        {
            _rotationInput = _playerRotationService.PlayerInput.Input.x;
        }
        public void FixedUpdateTick()
        {
            RotatePlayer(_rotationInput);
        }

        public void RotatePlayer(float rotationDirection)
        {
            if (Mathf.Approximately(rotationDirection, 0f)) return;
            float currentRotation = _playerRotationService.PlayerTransform.eulerAngles.z;
            float newRotation = currentRotation - rotationDirection * Time.fixedDeltaTime * _playerRotationService.PlayerRotateSO.RotationSpeed;
            newRotation = NormalizeAngle(newRotation);
            newRotation = Mathf.Clamp(newRotation, -_playerRotationService.PlayerRotateSO.RotationLimit, _playerRotationService.PlayerRotateSO.RotationLimit);

            _playerRotationService.PlayerTransform.rotation = Quaternion.Euler(0f, 0f, newRotation);
        }
        private float NormalizeAngle(float angle)
        {
            return Mathf.DeltaAngle(0f, angle);
        }
    }

}