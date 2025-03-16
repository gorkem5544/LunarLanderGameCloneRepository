using Assembly_CSharp.Assets.Scripts.EnumScripts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.StateMachineScripts.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.StateMachineScripts.Concretes.GameManagerStates
{
    public class GameInState : IState
    {
        private GameManager _gameManager;

        public GameInState(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void EnterState()
        {


            _gameManager.GameStarting();
            UiManager.Instance.CloseLandingMissionEvent();
            SoundManager.Instance.PlaySound(GameSoundTypeEnum.GameInMusic);
        }

        public void ExitState()
        {
            SoundManager.Instance.PlaySound(GameSoundTypeEnum.GameInMusic);
        }

        public void UpdateState()
        {
            Debug.Log("Updating Game In State");

        }
    }

}