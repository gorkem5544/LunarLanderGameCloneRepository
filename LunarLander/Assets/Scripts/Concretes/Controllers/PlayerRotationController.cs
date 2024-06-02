using System;
using UnityEngine;

public class PlayerRotationController
{
    private readonly PlayerController _playerController;
    private readonly PlayerInput _playerInput;
    private readonly float _rotationLimit = 90f;
    private readonly float _rotationSpeed = 25f;

    public PlayerRotationController(PlayerController playerController, PlayerInput playerInput)
    {
        _playerController = playerController;
        _playerInput = playerInput;
    }

    public void UpdateRotation()
    {
        RotatePlayer(_playerInput.GetInput().x);
    }

    private void RotatePlayer(float rotationDirection)
    {
        float currentRotation = _playerController.transform.eulerAngles.z;
        float newRotation = currentRotation + rotationDirection * Time.fixedDeltaTime * _rotationSpeed;
        newRotation = NormalizeAngle(newRotation);
        newRotation = Mathf.Clamp(newRotation, -_rotationLimit, _rotationLimit);
        _playerController.transform.rotation = Quaternion.Euler(0f, 0f, newRotation);
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