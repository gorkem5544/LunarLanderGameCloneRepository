using Assembly_CSharp.Assets.Scripts.EnumScripts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.StateMachineScripts.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.StateMachineScripts.Concretes.GameManagerStates
{
    public class MissionCompleteState : IState
{
    private GameManager _gameManager;
    private float _currentTime = 0;

    public MissionCompleteState(GameManager gameManager)
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
        _currentTime += Time.deltaTime;
        if (_currentTime >= 3)
        {
            _gameManager.TransitionToState(GameManagerStateEnum.GameRestartingState);
        }
        Debug.Log("Updating Mission Complete State");

    }
}

}