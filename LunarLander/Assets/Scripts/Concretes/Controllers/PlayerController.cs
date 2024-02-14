using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigidbody2D;
    private PlayerForceUpMovement _playerForceUpMovement;
    private FuelController _fuelController;
    private PlayerRotate _playerRotate;
    PlayerInput _playerInput;
    private IScoreManager _scoreManager;

    public FuelController FuelController { get => _fuelController; set => _fuelController = value; }
    public IScoreManager ScoreManager { get => _scoreManager; set => _scoreManager = value; }

    private void Awake()
    {
        _playerInput = new PlayerInput();
        ScoreManager = new ScoreManager();
        _playerRotate = new PlayerRotate(this, _playerInput);
        FuelController = new FuelController(600);
        _playerForceUpMovement = new PlayerForceUpMovement(_playerRigidbody2D, _playerInput, 2, FuelController);
    }
    private void Start()
    {
        FuelController.StartTick();
    }
    private void Update()
    {
        if (GameManager.Instance.GameFinished)
        {
            SoundManager.Instance.StopSound(SoundManagerTypeEnum.LaunchSound);
            enabled = false;
        }
        _playerForceUpMovement.UpdateTick();
        Debug.Log(_scoreManager.Score);

    }
    private void FixedUpdate()
    {
        _playerForceUpMovement.FixedTick();
        _playerRotate.UpdateTick();
    }
    public Vector2 PlayerVelocity()
    {
        return _playerRigidbody2D.GetVector(_playerRigidbody2D.velocity) * 100;
    }
}

public class PlayerForceUpMovement
{
    PlayerInput _playerInput;
    Rigidbody2D _playerRigidbody2D;
    private float _forceSpeed;
    private bool _canForceUp = false;
    FuelController _fuelController;
    public PlayerForceUpMovement(Rigidbody2D playerRigidbody2D, PlayerInput playerInput, float forceSpeed, FuelController fuelController)
    {
        _playerRigidbody2D = playerRigidbody2D;
        _playerInput = playerInput;
        _forceSpeed = forceSpeed;
        _fuelController = fuelController;
    }
    public void UpdateTick()
    {
        if (_playerInput.GetInput().y > 0)
        {
            _canForceUp = true;
        }
        else
        {
            _canForceUp = false;
        }
    }
    public void FixedTick()
    {
        if (_canForceUp)
        {
            ForceUp(_forceSpeed);
        }
        else
        {
            SoundManager.Instance.StopSound(SoundManagerTypeEnum.LaunchSound);

        }
    }
    public void ForceUp(float forceValue)
    {
        _fuelController.FuelDecrease(0.15f);
        if (!_fuelController.IsEmpty)
        {
            _playerRigidbody2D.AddRelativeForce(_playerRigidbody2D.transform.up * forceValue * Time.fixedDeltaTime);
            SoundManager.Instance.PlaySound(SoundManagerTypeEnum.LaunchSound);
        }
    }
}

public class PlayerRotate
{
    PlayerController _playerController;
    PlayerInput _playerInput;
    public PlayerRotate(PlayerController playerController, PlayerInput playerInput)
    {
        _playerController = playerController;
        _playerInput = playerInput;
    }
    public void UpdateTick()
    {
        RotationAction(_playerInput.GetInput().x, 5f);
    }
    public void RotationAction(float direction, float speed)
    {
        _playerController.transform.Rotate(Vector3.back * direction * Time.fixedDeltaTime * speed);
    }
}