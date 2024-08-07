using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerInputs.Abstracts;
using Unity.Mathematics;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerInputs.Concretes
{
    public class PlayerInput : IPlayerInput
    {
        InputConroller _inputController;
        private Vector2 _input;
        public Vector2 Input { get => _input; set => _input = value; }
        public PlayerInput()
        {
            _inputController = new InputConroller();
            _inputController.Enable();
            _inputController.PlayerInputs.WASD.performed += context => _input = context.ReadValue<Vector2>();
        }

        public Vector2 GetInput()
        {
            return new Vector2(_input.x, math.max(0, _input.y));
        }

    }
}
