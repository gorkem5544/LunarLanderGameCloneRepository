using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Abstracts;
using Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Concretes
{
    public class PlayerFuelService : IPlayerFuelService
    {

        IPlayerFuelSO _playerFuelSO;
        public PlayerFuelService(IPlayerController playerController)
        {
            _playerFuelSO = playerController.PlayerFuelSO;
        }

        public IPlayerFuelSO PlayerFuelSO => _playerFuelSO;
    }

}
public interface IPlayerFuelService
{
    IPlayerFuelSO PlayerFuelSO { get; }
}