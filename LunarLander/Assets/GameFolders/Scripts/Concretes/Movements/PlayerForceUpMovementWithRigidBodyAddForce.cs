using System;
using Assembly_CSharp.Assets.Scripts.EnumScripts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Concretes
{
    public class PlayerForceUpMovementWithRigidBodyAddForce : IPlayerForceUpMovement
    {
        private bool _canForceUp;
        IPlayerForceUpMovementService _playerForceUpMovementService;


        public PlayerForceUpMovementWithRigidBodyAddForce(IPlayerForceUpMovementService playerForceUpMovementService)
        {

            _playerForceUpMovementService = playerForceUpMovementService;

        }

        public void UpdateTick()
        {
            _canForceUp = _playerForceUpMovementService.PlayerInput.GetInput().y > 0;
        }

        public void FixedTick()
        {
            if (_canForceUp)
            {
                ApplyForceUp();
            }
            else
            {
                StopForceUp();
            }
        }

        public void ApplyForceUp()
        {
            if (_playerForceUpMovementService.PlayerFuel.IsEmpty)
            {
                _playerForceUpMovementService.PlayerFeedback.DeactivateFireParticle();
            }
            else
            {
                _playerForceUpMovementService.PlayerFuel.DecreaseFuel(0.15f);
                _playerForceUpMovementService.RigidBody2D.AddRelativeForce(Vector2.up * _playerForceUpMovementService.PlayerForceSO.ForceSpeed * Time.fixedDeltaTime);
                SoundManager.Instance.PlaySound(GameSoundTypeEnum.PlayerLaunchSound);
                _playerForceUpMovementService.PlayerFeedback.ActivateFireParticle();
            }


        }

        public void StopForceUp()
        {
            SoundManager.Instance.StopSound(GameSoundTypeEnum.PlayerLaunchSound);
            _playerForceUpMovementService.PlayerFeedback.DeactivateFireParticle();
            Vector2 frictionForce = new Vector2(-_playerForceUpMovementService.RigidBody2D.linearVelocity.x * _playerForceUpMovementService.PlayerForceSO.FrictionCoefficient, 0f);
            _playerForceUpMovementService.RigidBody2D.AddForce(frictionForce);
        }

    }

}