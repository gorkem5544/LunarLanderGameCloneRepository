using Assembly_CSharp.Assets.Scripts.ManagerScripts.Abstracts;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerInputs.Abstracts;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Abstracts
{
    public interface IPlayerController : IEntityController
    {
        IPlayerInput PlayerInput { get; }
        Rigidbody2D Rigidbody2D { get; }
        IPlayerFuel FuelController { get; }
        IPlayerForceSO PlayerForceSO { get; }
        IPlayerRotateSO PlayerRotateSO { get; }
        IPlayerFuelSO PlayerFuelSO { get; }
        Vector2 PlayerVelocity { get; }
        IScoreManager ScoreManager { get; }
        IPlayerFeedback PlayerFeedback { get; }
    }

}