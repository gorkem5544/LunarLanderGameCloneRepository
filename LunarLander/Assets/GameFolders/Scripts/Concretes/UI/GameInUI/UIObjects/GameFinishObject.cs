using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Concretes;
using Unity.Mathematics;
using UnityEngine;

public class GameFinishObject : MonoBehaviour
{
    [SerializeField] private GameFinishPanel _gameFinishPanel;
    [SerializeField] private DetermineLandingSO _determineLandingSO;
    [SerializeField] private LunaLandingMissionScenariosSO[] _landingMissionSuccessScenarios;
    [SerializeField] private LunaLandingMissionScenariosSO _landingMissionFailedScenario;
    [SerializeField] private LunaLandingMissionScenariosSO _NEWlunaLandingMissionScenariosSO;



    private void Start()
    {
        SetMissionPanelActive(false);
        UiManager.Instance.OpenLandingMissionEvent += Landing;
        UiManager.Instance.CloseLandingMissionEvent += HandleOnClosedLandingMissionPanel;
    }

    private void HandleOnClosedLandingMissionPanel()
    {
        SetMissionPanelActive(false);
    }

    private void OnDisable()
    {
        UiManager.Instance.OpenLandingMissionEvent -= Landing;
        UiManager.Instance.CloseLandingMissionEvent -= HandleOnClosedLandingMissionPanel;
    }
    private void Landing(float playerVelocityY, int totalScore)
    {
        float absVelocityY = Mathf.Abs(playerVelocityY);



        if (absVelocityY > _determineLandingSO.FallSpeedDestroyLanding)
        {
            OpenLandingMissionPanel(_landingMissionFailedScenario, totalScore);
        }
        else if (absVelocityY > _determineLandingSO.FallSpeedBadLanding)
        {
            OpenLandingMissionPanel(_landingMissionSuccessScenarios[2], totalScore);
        }
        else if (absVelocityY > _determineLandingSO.FallSpeedNormalLanding)
        {
            OpenLandingMissionPanel(_landingMissionSuccessScenarios[1], totalScore);
        }
        else if (absVelocityY > _determineLandingSO.FallSpeedPerfectLanding)
        {
            OpenLandingMissionPanel(_landingMissionSuccessScenarios[0], totalScore);
        }
        else
        {
            OpenLandingMissionPanel(_landingMissionFailedScenario, totalScore);
        }
    }

    private void OpenLandingMissionPanel(LunaLandingMissionScenariosSO scenario, int totalScore)
    {
        SetMissionPanelActive(true);
        _gameFinishPanel.Init(scenario, totalScore);
    }
    private void SetMissionPanelActive(bool canActive)
    {
        _gameFinishPanel.gameObject.SetActive(canActive);
    }







}


public class ScoreCalculate
{

}