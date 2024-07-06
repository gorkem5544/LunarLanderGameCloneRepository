using Assembly_CSharp.Assets.Scripts.EnumScripts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.StateMachineScripts.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.StateMachineScripts.Concretes.GameManagerStates
{
    public class MissionFailedState : IState
    {
        private GameManager _gameManager;
        private float _currentTime;

        public MissionFailedState(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void EnterState()
        {

            _currentTime = 0;

        }

        public void ExitState()
        {

            _currentTime = 0;


        }

        public void UpdateState()
        {
            Debug.Log("Updating Mission Failed State");
            _currentTime += Time.deltaTime;
            if (_currentTime >= 3)
            {
                _gameManager.TransitionToState(GameManagerStateEnum.GameRestartingState);
            }

        }
    }
}