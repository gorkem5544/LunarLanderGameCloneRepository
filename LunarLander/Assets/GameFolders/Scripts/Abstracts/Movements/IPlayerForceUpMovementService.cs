using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerInputs.Abstracts;
using Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts
{
    public interface IPlayerForceUpMovementService
    {
        IPlayerForceSO PlayerForceSO { get; }
        IPlayerInput PlayerInput { get; }
        IPlayerFuel PlayerFuel { get; }
        IPlayerFeedback PlayerFeedback { get; }
        Rigidbody2D RigidBody2D { get; }

    }

}