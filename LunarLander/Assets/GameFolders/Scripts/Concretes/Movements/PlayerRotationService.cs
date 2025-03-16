using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerInputs.Abstracts;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Concretes
{
    public class PlayerRotationService : IPlayerRotationService
    {
        private readonly PlayerController _playerController;

        public PlayerRotationService(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public IPlayerRotateSO PlayerRotateSO => _playerController.PlayerRotateSO;
        public IPlayerInput PlayerInput => _playerController.PlayerInput;

        public Transform PlayerTransform => _playerController.transform;
    }

}