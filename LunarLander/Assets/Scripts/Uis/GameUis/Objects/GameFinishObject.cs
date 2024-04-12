using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameFinishObject : MonoBehaviour
{
    [SerializeField] private GameFinishPanel _gameFinishPanel;
    [SerializeField] private LunaLandingMissionScenariosSO[] _landingMissionSuccessScenarios;
    [SerializeField] private LunaLandingMissionScenariosSO _landingMissionFailedScenarios;


    private void Start()
    {
        ChangedMissionPanelActivity(false);
        UiManager.Instance.OpenLandingMissionEvent += HandleJ;
        UiManager.Instance.CloseLandingMissionEvent += HandleOnClosedLandingMissionPanel;
    }

    private void HandleOnClosedLandingMissionPanel()
    {
        ChangedMissionPanelActivity(false);
    }

    private void OnDisable()
    {
        UiManager.Instance.OpenLandingMissionEvent -= HandleJ;
        UiManager.Instance.CloseLandingMissionEvent -= HandleOnClosedLandingMissionPanel;
    }
    private void HandleJ(float playerVelocityY, int totalScore)
    {
        switch (math.abs(playerVelocityY))
        {
            case > 25:
                OpenLandingMissionFailedScenarios(_landingMissionFailedScenarios, totalScore);
                break;
            case > 15:
                OpenLandingMissionSuccessScenarios(_landingMissionSuccessScenarios[1], totalScore);
                break;
            case > 0:
                OpenLandingMissionSuccessScenarios(_landingMissionSuccessScenarios[0], totalScore);
                break;
            default:
                OpenLandingMissionFailedScenarios(_landingMissionFailedScenarios, totalScore);
                break;
        }
    }

    private void OpenLandingMissionSuccessScenarios(LunaLandingMissionScenariosSO lunaLandingMissionSuccessScenariosSO, int TotalScore)
    {
        ChangedMissionPanelActivity(true);
        _gameFinishPanel.Init(lunaLandingMissionSuccessScenariosSO, TotalScore);
    }
    private void OpenLandingMissionFailedScenarios(LunaLandingMissionScenariosSO lunaLandingMissionFailedScenariosSO, int TotalScore)
    {
        ChangedMissionPanelActivity(true);
        _gameFinishPanel.Init(lunaLandingMissionFailedScenariosSO, TotalScore);
    }
    private void ChangedMissionPanelActivity(bool canActive)
    {
        _gameFinishPanel.gameObject.SetActive(canActive);
    }







}
