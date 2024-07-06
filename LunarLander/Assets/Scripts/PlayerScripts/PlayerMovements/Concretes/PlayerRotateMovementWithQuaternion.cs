using System;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Concretes
{
    public class PlayerRotateMovementWithQuaternion : IPlayerRotateMovement
    {
        IPlayerRotationService _playerRotationService;
        public PlayerRotateMovementWithQuaternion(IPlayerRotationService playerRotationService)
        {
            _playerRotationService = playerRotationService;
        }

        public void FixedUpdateRotation()
        {
            RotatePlayer(_playerRotationService.PlayerInput.GetInput().x);
        }

        public void RotatePlayer(float rotationDirection)
        {
            float currentRotation = _playerRotationService.PlayerTransform.eulerAngles.z;
            float newRotation = currentRotation + rotationDirection * Time.fixedDeltaTime * _playerRotationService.PlayerRotateSO.RotationSpeed;
            newRotation = NormalizeAngle(newRotation);
            newRotation = Mathf.Clamp(newRotation, -_playerRotationService.PlayerRotateSO.RotationLimit, _playerRotationService.PlayerRotateSO.RotationLimit);
            _playerRotationService.PlayerTransform.rotation = Quaternion.Euler(0f, 0f, newRotation);
        }

        private float NormalizeAngle(float angle)
        {
            if (angle > 180f)
            {
                angle -= 360f;
            }
            else if (angle < -180f)
            {
                angle += 360f;
            }
            return angle;
        }
    }

}