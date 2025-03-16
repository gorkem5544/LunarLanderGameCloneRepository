using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.EnumScripts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Abstracts;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.GroundScripts.Concretes
{
    public class GroundController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent<IPlayerController>(out IPlayerController playerController))
            {
                playerController.Rigidbody2D.bodyType = RigidbodyType2D.Static;
                if (playerController.FuelController.IsEmpty)
                {
                    GameManager.Instance.TransitionToState(GameManagerStateEnum.GameFinishedState);
                }
                else
                {
                    GameManager.Instance.TransitionToState(GameManagerStateEnum.MissionFailedState);
                    playerController.FuelController.ShipExplosionDecreaseFuel();
                }

            }

        }
    }

}