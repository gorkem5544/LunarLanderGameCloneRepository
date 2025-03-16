using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Abstracts;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Concretes
{
    public class PlayerPositionResetService : IPlayerPositionResetService
    {
        private readonly Vector2 _initialPosition;
        private readonly Vector2 _initialEulerAngles;
        private PlayerController _playerController;

        public PlayerPositionResetService(PlayerController playerController, Vector2 initialPosition, Vector2 initialEulerAngles)
        {
            _playerController = playerController;
            _initialPosition = initialPosition;
            _initialEulerAngles = initialEulerAngles;
        }

        public IPlayerController PlayerController => _playerController;

        public Vector2 InitialPosition => _initialPosition;

        public Vector2 InitialEulerAngles => _initialEulerAngles;


    }

}