using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Concretes
{
    public class PlayerPositionReset : IPlayerPositionReset
    {
        IPlayerPositionResetService _playerPositionResetService;
        public PlayerPositionReset(IPlayerPositionResetService playerPositionResetService)
        {
            _playerPositionResetService = playerPositionResetService;
        }
        public void ResetPosition()
        {
            _playerPositionResetService.PlayerController.transform.position = _playerPositionResetService.InitialPosition;
            _playerPositionResetService.PlayerController.Rigidbody2D.freezeRotation = true;
            _playerPositionResetService.PlayerController.Rigidbody2D.velocity = Vector3.zero;
            _playerPositionResetService.PlayerController.Rigidbody2D.freezeRotation = false;
            _playerPositionResetService.PlayerController.transform.rotation = Quaternion.Euler(_playerPositionResetService.InitialEulerAngles);
        }
    }

}