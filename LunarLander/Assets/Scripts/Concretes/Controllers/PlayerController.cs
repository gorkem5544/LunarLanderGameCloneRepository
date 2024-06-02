using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : AbstractPlayerController
{

    private PlayerForceUpMovement _playerForceUpMovement;
    private PlayerFuel _fuelController;
    private PlayerRotationController _playerRotate;
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
        _playerRotate = new PlayerRotationController(this, _playerInput);
        _fuelController = new PlayerFuel();
        _playerForceUpMovement = new PlayerForceUpMovement(_playerRigidbody2D, _playerInput, 5, _fuelController, _fireParticle);
    }
    private void Start()
    {
        _fuelController.UpdateGameStartingFuel(150);
        _playerEuler = this.transform.eulerAngles;
        ResetPlayerPosition();

        GameManager.Instance.gameStartingEvent += ResetPlayerPosition;
        // SoundManager.Instance.SetVolume(SoundManagerTypeEnum.LaunchSound, 0.1f);
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
        _playerRotate.UpdateRotation();
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
