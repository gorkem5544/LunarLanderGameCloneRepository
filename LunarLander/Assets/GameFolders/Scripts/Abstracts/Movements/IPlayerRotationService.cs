using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerInputs.Abstracts;
using Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts
{
    public interface IPlayerRotationService
    {
        IPlayerRotateSO PlayerRotateSO { get; }
        IPlayerInput PlayerInput { get; }
        Transform PlayerTransform { get; }
    }

}