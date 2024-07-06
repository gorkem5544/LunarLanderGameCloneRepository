using Assembly_CSharp.Assets.Scripts.ManagerScripts.Abstracts;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Abstracts;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes
{
    public interface IBasePlayerController : IEntityController
    {
        Vector2 PlayerVelocity { get; }
        Rigidbody2D Rigidbody2D { get; }


    }

}