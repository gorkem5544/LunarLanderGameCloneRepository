using System;
using System.Collections;
using UnityEngine;
public enum GameManagerStateEnum
{
    MenuState, GameInitializeState, GameInState, GameFinishedState, GameManagerGameRestartingState, GameManagerMissionCompleteSate, GameManagerMissionFailedState
}

public class GameManager : SingletonDontDestroyObject<GameManager>
{
    [SerializeField] private UiManager _uiManager;
    private GameManagerStateMachine _gameManagerStateMachine;
    public GameManagerStateMachine GameManagerStateMachine { get => _gameManagerStateMachine; set => _gameManagerStateMachine = value; }
    public event System.Action<float, int> MissionCompleteEvent;
    PlayerController _playerController;
    public bool GameFinished { get; set; }
    public UiManager UiManager { get => _uiManager; set => _uiManager = value; }
    public PlayerController PlayerController { get => _playerController; set => _playerController = value; }

    public event System.Action gameStartingEvent;

    protected override void Awake()
    {
        base.Awake();
        _playerController = FindObjectOfType<PlayerController>();
        GameManagerStateMachine = new GameManagerStateMachine(this);
    }
    private void Start()
    {
        GameManagerStateMachine.SetState(GameManagerStateMachine.GameManagerMenuState);
    }
    private void Update()
    {
        GameManagerStateMachine.UpdateState();
    }
    public void LandingMission(float playerVelocityY, int score)
    {
        MissionCompleteEvent?.Invoke(playerVelocityY, score);
        // _uiManager.OnMissionSuccessEvent?.Invoke();
        GameFinished = true;
    }
    public void GameStarting()
    {
        gameStartingEvent?.Invoke();
        GameFinished = false;
    }

}

[Serializable]
public class GameManagerStateMachine
{

    public IState CurrentState { get; private set; }
    public GameManagerMenuState GameManagerMenuState { get; private set; }
    public GameManagerGameInState GameManagerGameInState { get; private set; }
    public GameManagerMissionOverSate GameManagerMissionOverSate { get; private set; }
    public GameManagerGameOverState GameManagerGameOverState { get; private set; }


    public GameManagerStateMachine(GameManager gameManager)
    {
        GameManagerMenuState = new GameManagerMenuState(gameManager);
        GameManagerGameInState = new GameManagerGameInState(gameManager);
        GameManagerMissionOverSate = new GameManagerMissionOverSate(gameManager);
        GameManagerGameOverState = new GameManagerGameOverState(gameManager);
    }
    public void SetState(IState state)
    {
        CurrentState = state;
        CurrentState.EnterState();
    }
    public void StateMachineTransitionState(IState to)
    {
        CurrentState?.ExitState();
        CurrentState = to;
        CurrentState?.EnterState();
    }
    public void UpdateState()
    {
        CurrentState?.UpdateState();
    }
}


public class GameManagerMenuState : IState
{
    private GameManager _gameManager;
    public GameManagerMenuState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void EnterState()
    {
        SoundManager.Instance.PlaySound(SoundManagerTypeEnum.MenuSound);
    }

    public void ExitState()
    {
        SoundManager.Instance.StopSound(SoundManagerTypeEnum.MenuSound);

    }

    public void UpdateState()
    {

        Debug.Log("Menu State");
    }
}

public class GameManagerGameInState : IState
{
    private GameManager _gameManager;
    public GameManagerGameInState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void EnterState()
    {
        UiManager.Instance.CloseLandingMissionEvent();
        _gameManager.GameStarting();
        SoundManager.Instance.StopSound(SoundManagerTypeEnum.MenuSound);
        SoundManager.Instance.PlaySound(SoundManagerTypeEnum.GameSound);

    }

    public void ExitState()
    {

    }

    public void UpdateState()
    {
        Debug.Log("GameManager Game In State");
    }

}
public class GameManagerGameOverState : IState
{
    private float _timer = 0;
    GameManager _gameManager;

    public GameManagerGameOverState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void EnterState()
    {
        _timer = 0;
    }

    public void ExitState()
    {
        _timer = 0;
    }

    public void UpdateState()
    {
        _timer += Time.deltaTime;
        if (_timer > 3)
        {
            LevelManager.Instance.LoadMenu();
            _gameManager.GameManagerStateMachine.StateMachineTransitionState(_gameManager.GameManagerStateMachine.GameManagerMenuState);
        }
        Debug.Log("Game Manager Game Over State");
    }
}

public class GameManagerMissionOverSate : IState
{
    private float _currentTime = 0;
    GameManager _gameManager;

    public GameManagerMissionOverSate(GameManager gameManager)
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
        UiManager.Instance.CloseLandingMissionEvent();
    }

    public void UpdateState()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= 3)
        {
            _gameManager.GameManagerStateMachine.StateMachineTransitionState(_gameManager.GameManagerStateMachine.GameManagerGameInState);
        }
        Debug.Log("GameManager Mission Over State");
    }

}
public interface IState
{
    void EnterState();
    void ExitState();
    void UpdateState();
}