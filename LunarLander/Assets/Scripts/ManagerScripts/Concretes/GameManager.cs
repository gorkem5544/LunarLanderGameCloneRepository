using System.Collections;
using Assembly_CSharp.Assets.Scripts.EnumScripts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Abstracts;
using Assembly_CSharp.Assets.Scripts.StateMachineScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.StateMachineScripts.Concretes.GameManagerStates;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes
{
    public class GameManager : SingletonDontDestroyObject<GameManager>
    {
        public event System.Action gameStartingEvent;
        private StateMachine _stateMachine;

        //[SerializeField] private SoundManager _soundManager;
        //public SoundManager SoundManager => _soundManager;

        //private SoundManager soundManager;

        protected override void Awake()
        {
            base.Awake();

            _stateMachine = new StateMachine();
        }
        private void Start()
        {

            var menuState = new MenuState(this);
            var gameInState = new GameInState(this);
            var gameFinishedState = new GameFinishedState(this);
            var gameRestartingState = new GameRestartingState(this);
            var missionCompleteState = new MissionCompleteState(this);
            var missionFailedState = new MissionFailedState(this);

            _stateMachine.AddState(GameManagerStateEnum.MenuState, menuState);
            _stateMachine.AddState(GameManagerStateEnum.GameInState, gameInState);
            _stateMachine.AddState(GameManagerStateEnum.GameFinishedState, gameFinishedState);
            _stateMachine.AddState(GameManagerStateEnum.GameRestartingState, gameRestartingState);
            _stateMachine.AddState(GameManagerStateEnum.MissionCompleteState, missionCompleteState);
            _stateMachine.AddState(GameManagerStateEnum.MissionFailedState, missionFailedState);
            _stateMachine.SetInitialState(GameManagerStateEnum.MenuState);
        }
        private void Update()
        {
            _stateMachine.Update();
        }
        public void GameStarting()
        {
            gameStartingEvent?.Invoke();

        }
        public void TransitionToState(GameManagerStateEnum state)
        {
            _stateMachine.TransitionToState(state);
        }

    }

}