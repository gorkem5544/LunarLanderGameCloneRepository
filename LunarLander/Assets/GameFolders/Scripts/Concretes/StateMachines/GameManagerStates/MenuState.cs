using Assembly_CSharp.Assets.Scripts.EnumScripts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.StateMachineScripts.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.StateMachineScripts.Concretes.GameManagerStates
{
    public class MenuState : IState
    {
        private GameManager _gameManager;

        public MenuState(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void EnterState()
        {
            SoundManager.Instance.PlaySound(GameSoundTypeEnum.MenuMusic);
        }

        public void ExitState()
        {
            SoundManager.Instance.StopSound(GameSoundTypeEnum.MenuMusic);
        }

        public void UpdateState()
        {
            Debug.Log("Updating Menu State");

        }
    }

}