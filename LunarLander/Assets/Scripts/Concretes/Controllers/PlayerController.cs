using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : AbstractPlayerController
{

    private PlayerForceUpMovement _playerForceUpMovement;
    private PlayerFuel _fuelController;
    private PlayerRotate _playerRotate;
    PlayerInput _playerInput;
    private IScoreManager _scoreManager;

    public PlayerFuel FuelController { get => _fuelController; set => _fuelController = value; }
    public IScoreManager ScoreManager { get => _scoreManager; set => _scoreManager = value; }
    [SerializeField] private GameObject _fireParticle;
    Vector2 _playerEuler;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        ScoreManager = new ScoreManager();
        _playerRotate = new PlayerRotate(this, _playerInput);
        _fuelController = new PlayerFuel();
        _playerForceUpMovement = new PlayerForceUpMovement(_playerRigidbody2D, _playerInput, 5, _fuelController, _fireParticle);
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
        _playerRotate.UpdateTick();
    }



    public void ResetPlayerPosition()
    {
        this.transform.position = new Vector2(-7, 3);
        _playerRigidbody2D.freezeRotation = true;
        _playerRigidbody2D.velocity = Vector3.zero;
        _playerRigidbody2D.freezeRotation = false;
        this.transform.rotation = Quaternion.Euler(_playerEuler);
    }
}

public class PlayerForceUpMovement
{
    PlayerInput _playerInput;
    Rigidbody2D _playerRigidbody2D;
    private float _forceSpeed;
    private bool _canForceUp = false;
    PlayerFuel _fuelController;
    private GameObject _fireParticle;
    private float _frictionCoefficient = 0.1f;
    public PlayerForceUpMovement(Rigidbody2D playerRigidbody2D, PlayerInput playerInput, float forceSpeed, PlayerFuel fuelController, GameObject fireParticle)
    {
        _playerRigidbody2D = playerRigidbody2D;
        _playerInput = playerInput;
        _forceSpeed = forceSpeed;
        _fuelController = fuelController;
        _fireParticle = fireParticle;
    }
    public void UpdateTick()
    {
        _canForceUp = _playerInput.GetInput().y > 0;
    }

    public void FixedTick()
    {
        if (_canForceUp)
        {
            ForceUp(_forceSpeed);
        }
        else
        {
            StopLaunch();
        }
    }

    public void ForceUp(float forceValue)
    {
        if (_fuelController.IsEmpty)
            return;

        _fuelController.FuelDecrease(0.15f);
        _playerRigidbody2D.AddRelativeForce(Vector2.up * forceValue * Time.fixedDeltaTime);

        SoundManager.Instance.PlaySound(SoundManagerTypeEnum.LaunchSound);
        _fireParticle.gameObject.SetActive(true);
    }

    private void StopLaunch()
    {
        SoundManager.Instance.StopSound(SoundManagerTypeEnum.LaunchSound);
        _fireParticle.gameObject.SetActive(false);
        Vector2 frictionForce = new Vector2(-_playerRigidbody2D.velocity.x * _frictionCoefficient, 0f);
        _playerRigidbody2D.AddForce(frictionForce);
    }

}

public class PlayerRotate
{
    PlayerController _playerController;
    PlayerInput _playerInput;
    private float _rotationLimit = 90;
    private float _newRotation;
    private float _rotationSpeed = 25;
    public PlayerRotate(PlayerController playerController, PlayerInput playerInput)
    {
        _playerController = playerController;
        _playerInput = playerInput;
    }
    public void UpdateTick()
    {
        RotationAction(_playerInput.GetInput().x);
    }
    public void RotationAction(float direction)
    {
        float currentRotation = _playerController.transform.eulerAngles.z;
        float newRotation = currentRotation + direction * Time.fixedDeltaTime * _rotationSpeed;
        if (newRotation > 180f)
        {
            newRotation -= 360f;
        }
        else if (newRotation < -180f)
        {
            newRotation += 360f;
        }
        newRotation = Mathf.Clamp(newRotation, -_rotationLimit, _rotationLimit);
        _playerController.transform.rotation = Quaternion.Euler(0f, 0f, newRotation);
    }
}