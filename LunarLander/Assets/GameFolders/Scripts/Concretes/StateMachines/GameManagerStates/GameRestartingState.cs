using Assembly_CSharp.Assets.Scripts.EnumScripts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.StateMachineScripts.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.StateMachineScripts.Concretes.GameManagerStates
{
    public class GameRestartingState : IState
    {
        private GameManager _gameManager;

        public GameRestartingState(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void EnterState()
        {

            _gameManager.GameStarting();
            UiManager.Instance.CloseLandingMissionEvent();

        }

        public void ExitState()
        {

        }

        public void UpdateState()
        {
            Debug.Log("Updating Game Restarting State");
            _gameManager.TransitionToState(GameManagerStateEnum.GameInState);

        }
    }

}