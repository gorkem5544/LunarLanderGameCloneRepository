using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : AbstractPlayerController, IPlayerController
{
    [SerializeField] private PlayerSO _playerSO;
    public IPlayerForceSO PlayerForceSO => _playerSO;
    public IPlayerRotateSO PlayerRotateSO => _playerSO;

    private PlayerForceUpMovement _playerForceUpMovement;
    private PlayerRotationController _playerRotate;

    private PlayerFuel _fuelController;
    public PlayerFuel FuelController => _fuelController;

    private IScoreManager _scoreManager;
    public IScoreManager ScoreManager => _scoreManager;

    PlayerInput _playerInput;
    public IPlayerInput PlayerInput => _playerInput;

    public Rigidbody2D Rigidbody2D => _playerRigidbody2D;

    PlayerPositionResetService _playerPositionResetService;

    [SerializeField] private GameObject _fireParticle;
    Vector2 _playerEuler;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _scoreManager = new ScoreManager();
        _fuelController = new PlayerFuel();
        _playerRotate = new PlayerRotationController(new PlayerRotationService(this));
        _playerForceUpMovement = new PlayerForceUpMovement(_fireParticle, new playerForceUpMovementService(this));
        _playerPositionResetService = new PlayerPositionResetService(this.transform, _playerRigidbody2D, new Vector2(-7, 3), transform.eulerAngles);

    }
    private void Start()
    {
        _fuelController.UpdateGameStartingFuel(150);
        _playerEuler = this.transform.eulerAngles;
        ResetPlayerPosition();

        GameManager.Instance.gameStartingEvent += ResetPlayerPosition;
    }
    private void Update()
    {
        if (GameManager.Instance.GameFinished)
        {
            SoundManager.Instance.StopSound(SoundManagerTypeEnum.LaunchSound);

            _fireParticle.gameObject.SetActive(false);
            enabled = false;
        }
        _playerForceUpMovement.UpdateTick();
    }
    private void OnDisable()
    {
        GameManager.Instance.gameStartingEvent -= ResetPlayerPosition;

    }
    private void FixedUpdate()
    {
        _playerForceUpMovement.FixedTick();
        _playerRotate.FixedUpdateRotation();
    }



    public void ResetPlayerPosition()
    {
        _playerPositionResetService.ResetPosition();
        // this.transform.position = new Vector2(-7, 3);
        // _playerRigidbody2D.freezeRotation = true;
        // _playerRigidbody2D.velocity = Vector3.zero;
        // _playerRigidbody2D.freezeRotation = false;
        // this.transform.rotation = Quaternion.Euler(_playerEuler);
    }
}

public interface IPlayerForceUpMovementService
{
    IPlayerForceSO PlayerForceSO { get; }
    IPlayerInput PlayerInput { get; }
    PlayerFuel PlayerFuel { get; }
    Rigidbody2D Rigidbody2D { get; }


}
public interface IPlayerRotationService
{
    IPlayerRotateSO PlayerRotateSO { get; }
    IPlayerInput PlayerInput { get; }
    Transform PlayerTransform { get; }
}

public interface IEntityController
{
    Transform transform { get; }
}
public interface IPlayerController : IEntityController
{
    IPlayerInput PlayerInput { get; }
    Rigidbody2D Rigidbody2D { get; }
    PlayerFuel FuelController { get; }
    IPlayerForceSO PlayerForceSO { get; }
    IPlayerRotateSO PlayerRotateSO { get; }
}

public class playerForceUpMovementService : IPlayerForceUpMovementService
{
    private readonly PlayerController _playerController;
    public playerForceUpMovementService(PlayerController playerController)
    {
        _playerController = playerController;
    }
    public IPlayerForceSO PlayerForceSO => _playerController.PlayerForceSO;
    public IPlayerInput PlayerInput => _playerController.PlayerInput;
    public Rigidbody2D Rigidbody2D => _playerController.Rigidbody2D;
    public PlayerFuel PlayerFuel => _playerController.FuelController;
}
public class PlayerRotationService : IPlayerRotationService
{
    private readonly PlayerController _playerController;

    public PlayerRotationService(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public IPlayerRotateSO PlayerRotateSO => _playerController.PlayerRotateSO;
    public IPlayerInput PlayerInput => _playerController.PlayerInput;

    public Transform PlayerTransform => _playerController.transform;
}

public class PlayerPositionResetService
{
    private readonly Transform _playerTransform;
    private readonly Rigidbody2D _playerRigidbody2D;
    private readonly Vector2 _initialPosition;
    private readonly Vector2 _initialEulerAngles;

    public PlayerPositionResetService(Transform playerTransform, Rigidbody2D playerRigidbody2D, Vector2 initialPosition, Vector2 initialEulerAngles)
    {
        _playerTransform = playerTransform;
        _playerRigidbody2D = playerRigidbody2D;
        _initialPosition = initialPosition;
        _initialEulerAngles = initialEulerAngles;
    }

    public void ResetPosition()
    {
        _playerTransform.position = _initialPosition;
        _playerRigidbody2D.freezeRotation = true;
        _playerRigidbody2D.velocity = Vector3.zero;
        _playerRigidbody2D.freezeRotation = false;
        _playerTransform.rotation = Quaternion.Euler(_initialEulerAngles);
    }
}
