using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerInputs.Abstracts
{
    public interface IPlayerInput
    {
        public Vector2 Input { get; }
        Vector2 GetInput();
    }

}