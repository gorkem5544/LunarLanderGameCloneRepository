using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerInputs.Abstracts;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Concretes
{
    public class PlayerForceUpMovementService : IPlayerForceUpMovementService
    {
        private readonly PlayerController _playerController;
        public PlayerForceUpMovementService(PlayerController playerController)
        {
            _playerController = playerController;
        }
        public IPlayerForceSO PlayerForceSO => _playerController.PlayerForceSO;
        public IPlayerInput PlayerInput => _playerController.PlayerInput;
        public Rigidbody2D Rigidbody2D => _playerController.Rigidbody2D;
        public IPlayerFuel PlayerFuel => _playerController.FuelController;

        public IPlayerFeedback PlayerFeedback => _playerController.PlayerFeedback;
    }

}