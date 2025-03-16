using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.EnumScripts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Abstracts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Abstracts;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerInputs.Abstracts;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerInputs.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Concretes;
using Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Abstracts;
using Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Concretes;
using Unity.Mathematics;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes
{
    public class PlayerController : AbstractPlayerController, IPlayerController
    {
        [SerializeField] private PlayerSO _playerSO;
        [SerializeField] private GameObject _fireParticle;
        public IPlayerForceSO PlayerForceSO => _playerSO;
        public IPlayerRotateSO PlayerRotateSO => _playerSO;
        public IPlayerFuelSO PlayerFuelSO => _playerSO;


        private IPlayerForceUpMovement _playerForceUpMovement;
        private IPlayerRotateMovement _playerRotate;

        private IPlayerFuel _fuelController;
        public IPlayerFuel FuelController => _fuelController;

        private IScoreManager _scoreManager;
        public IScoreManager ScoreManager => _scoreManager;

        IPlayerInput _playerInput;
        public IPlayerInput PlayerInput => _playerInput;

        public IPlayerFeedback PlayerFeedback => _playerFeedbackService;


        IPlayerPositionResetService _playerPositionResetService;
        IPlayerPositionReset _playerPositionReset;

        IPlayerFeedback _playerFeedbackService;
        IPlayerRotationService _playerRotateService;
        IPlayerForceUpMovementService _playerForceUpMovementService;
        IPlayerFuelService _playerFuelService;


        protected override void Awake()
        {

            base.Awake();
            InitializeDependencies();

            InitializePlayerMovements();

        }
        private void Start()
        {
            ResetPlayerPosition();
            GameManager.Instance.gameStartingEvent += ResetPlayerPosition;
        }
        private void Update()
        {
            _playerForceUpMovement.UpdateTick();
            _playerRotate.UpdateTick();
        }
        private void OnDisable()
        {
            GameManager.Instance.gameStartingEvent -= ResetPlayerPosition;

        }
        private void FixedUpdate()
        {

            _playerRotate.FixedUpdateTick();
            _playerForceUpMovement.FixedTick();
        }

        public void ResetPlayerPosition()
        {
            _playerPositionReset.ResetPosition();
            _playerRigidBody2D.bodyType = RigidbodyType2D.Dynamic;
        }
        private void InitializeDependencies()
        {
            _playerInput = new PlayerInput();
            _playerFeedbackService = new PlayerFeedback(_fireParticle);
            _scoreManager = new ScoreManager();

            InitializePlayerPositionReset();
            InitializePlayerFuel();

        }

        private void InitializePlayerPositionReset()
        {
            _playerPositionResetService = new PlayerPositionResetService(this, new Vector2(-7, 3), transform.eulerAngles);
            _playerPositionReset = new PlayerPositionReset(_playerPositionResetService);
        }

        private void InitializePlayerFuel()
        {
            _playerFuelService = new PlayerFuelService(this);
            _fuelController = new PlayerFuel(_playerFuelService);
        }

        #region Movements
        private void InitializePlayerMovements()
        {
            InitializePlayerForceUpMovement();
            InitializePlayerRotation();
        }
        private void InitializePlayerForceUpMovement()
        {
            _playerForceUpMovementService = new PlayerForceUpMovementService(this);
            _playerForceUpMovement = new PlayerForceUpMovementWithRigidBodyAddForce(_playerForceUpMovementService);
        }
        private void InitializePlayerRotation()
        {
            _playerRotateService = new PlayerRotationService(this);
            _playerRotate = new PlayerRotateMovementWithQuaternion(_playerRotateService);
        }
        #endregion
    }

}