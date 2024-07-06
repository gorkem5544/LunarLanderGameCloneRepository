using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.CameraScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes;
using Assembly_CSharp.Assets.Scripts.Uis.GameUis.Icons;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.InitializerScripts.Concretes
{
    public class GameInitializer : MonoBehaviour
    {

        [Header("UI Elements - Horizontal Speed")]
        [SerializeField] private HorizontalSpeedValueText _horizontalSpeedText;
        [SerializeField] private HorizontalSpeedIcon _horizontalSpeedIcon;

        [Header("UI Elements - Vertical Speed")]
        [SerializeField] private VerticalSpeedValueText _verticalSpeedValueText;
        [SerializeField] private VerticalSpeedIcon _verticalSpeedIcon;

        [Header("Player Settings")]
        [SerializeField] private PlayerController _playerControllerPrefab;
        [SerializeField] private Vector3 _playerStartPosition;
        private PlayerController _playerControllerInstance;

        [Header("UI Elements - Player Info")]
        [SerializeField] private PlayerAltitudeDisplayText _playerAltitudeDisplayText;
        [SerializeField] private FuelText _fuelText;
        [SerializeField] private ScoreUi _scoreUi;

        [Header("Game Components")]
        [SerializeField] private CameraController _cameraController;

        private void Awake()
        {
            InitializePlayerController();
            InitializeUIElements();
            InitializeCameraController();
        }

        private void InitializePlayerController()
        {
            _playerControllerInstance = Instantiate(_playerControllerPrefab);
            _playerControllerInstance.transform.position = _playerStartPosition;
        }

        private void InitializeUIElements()
        {
            _horizontalSpeedText.Initialize(_playerControllerInstance);
            _horizontalSpeedIcon.Initialize(_playerControllerInstance);


            _verticalSpeedValueText.Initialize(_playerControllerInstance);
            _verticalSpeedIcon.Initialize(_playerControllerInstance);


            _playerAltitudeDisplayText.Initialize(_playerControllerInstance);
            _fuelText.Initialize(_playerControllerInstance);
            _scoreUi.Initialize(_playerControllerInstance);
        }

        private void InitializeCameraController()
        {
            _cameraController.Initialize(_playerControllerInstance);
        }
    }

}