using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts
{
    public interface IPlayerPositionResetService
{
    IPlayerController PlayerController { get; }
    Vector2 InitialPosition { get; }
    Vector2 InitialEulerAngles { get; }
}

}