using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : SingletonDontDestroyObject<UiManager>
{
    public System.Action<bool, LandingMissionTypeEnum> OnMissionSuccessEvent { get; set; }
    public System.Action<bool, LandingMissionTypeEnum> OnMissionFailedEvent { get; set; }
    public System.Action<float, int> OpenLandingMissionEvent { get; set; }
    public System.Action CloseLandingMissionEvent { get; set; }
    public System.Action<bool> FuelAlertUİ { get; set; }

    public void OpenLandingMissionSuccessPanel(LandingMissionTypeEnum landingMissionTypeEnum, float velocityY)
    {
        OnMissionSuccessEvent?.Invoke(true, landingMissionTypeEnum);
    }
    public void CloseLandingMissionSuccessPanel(LandingMissionTypeEnum landingMissionTypeEnum)
    {
        OnMissionSuccessEvent?.Invoke(false, landingMissionTypeEnum);
    }
    public void OpenLandingMissionFailedPanel(LandingMissionTypeEnum landingMissionTypeEnum)
    {
        OnMissionFailedEvent?.Invoke(true, landingMissionTypeEnum);
    }
    public void CloseLandingMissionFailedPanel(LandingMissionTypeEnum landingMissionTypeEnum)
    {
        OnMissionFailedEvent?.Invoke(false, landingMissionTypeEnum);
    }

    public void OpenLandingMissionPanel(float playerVelocityY, int TotalScore)
    {
        OpenLandingMissionEvent?.Invoke(playerVelocityY, TotalScore);
    }
    public void CloseLandingMissionPanel()
    {
        CloseLandingMissionEvent?.Invoke();
    }

}
public interface IUiSwitch
{
    void OpeningPanel();
    void ClosingPanel();

}