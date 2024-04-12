using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
enum PlatformMultipleScoreTypeEnum
{
    Five, Four, Three, Two, One
}
public enum LandingMissionTypeEnum
{
    PerfectLanding, HardLanding, FailedLanding
}
public class PlatformController : MonoBehaviour
{
    [SerializeField] private TextMeshPro _multipleScoreInfoText;
    private PlatformMultipleScoreTypeEnum _platformMultipleScoreTypeEnum;
    LandingMissionTypeEnum _landingMissionTypeEnum;
    PlayerFuel _playerFuel;


    private void Start()
    {
        //ChangedPlatformMultipleScoreValue();
        ChangedPlatformMultipleScoreValue2();
        GameManager.Instance.gameStartingEvent += ChangedPlatformMultipleScoreValue2;
    }
    private void OnDisable()
    {
        GameManager.Instance.gameStartingEvent -= ChangedPlatformMultipleScoreValue2;

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out PlayerController playerController))
        {
            float hitSpeed = other.relativeVelocity.magnitude * 100;
            UiManager.Instance.OpenLandingMissionEvent(hitSpeed, TotalScore());
            playerController.ScoreManager.AddScore(TotalScore());
            _playerFuel = playerController.FuelController;
            playerController.FuelController.UpdateGameStartingFuel(_playerFuel.GameStartingFuel - (_playerFuel.GameStartingFuel - _playerFuel.CurrentFuel));


            if (_playerFuel.IsEmpty)
            {
                GameManager.Instance.GameManagerStateMachine.StateMachineTransitionState(GameManager.Instance.GameManagerStateMachine.GameManagerGameOverState);
            }
            else
            {
                GameManager.Instance.GameManagerStateMachine.StateMachineTransitionState(GameManager.Instance.GameManagerStateMachine.GameManagerMissionOverSate);
            }
        }
    }
    public int TotalScore()
    {
        int score = 50;
        switch (_platformMultipleScoreTypeEnum)
        {
            case PlatformMultipleScoreTypeEnum.One:
                score *= 1;
                break;
            case PlatformMultipleScoreTypeEnum.Two:
                score *= 2;
                break;
            case PlatformMultipleScoreTypeEnum.Three:
                score *= 3;
                break;
            case PlatformMultipleScoreTypeEnum.Four:
                score *= 4;
                break;
            case PlatformMultipleScoreTypeEnum.Five:
                score *= 5;
                break;
        }
        return score;
    }
    private void UpdateMultipleScoreInfoText(int multipleValue, bool canActive = true)
    {
        _multipleScoreInfoText.gameObject.SetActive(canActive);
        _multipleScoreInfoText.text = $"x{multipleValue}";
    }
    public void ChangedPlatformMultipleScoreValue()
    {
        int chance = Random.Range(0, 100);
        if (chance <= 15)
        {
            _platformMultipleScoreTypeEnum = PlatformMultipleScoreTypeEnum.Five;
            UpdateMultipleScoreInfoText(5, true);
        }
        else if (chance <= 25)
        {
            _platformMultipleScoreTypeEnum = PlatformMultipleScoreTypeEnum.Four;
            UpdateMultipleScoreInfoText(4, true);

        }
        else if (chance <= 35)
        {
            _platformMultipleScoreTypeEnum = PlatformMultipleScoreTypeEnum.Three;
            UpdateMultipleScoreInfoText(3, true);

        }
        else if (chance <= 50)
        {
            _platformMultipleScoreTypeEnum = PlatformMultipleScoreTypeEnum.Two;
            UpdateMultipleScoreInfoText(2, true);
        }
        else
        {
            _platformMultipleScoreTypeEnum = PlatformMultipleScoreTypeEnum.One;
            UpdateMultipleScoreInfoText(1, false);
        }
    }

    public int TotalScore2()
    {
        int score = 50 * (int)_platformMultipleScoreTypeEnum;
        return score;
    }

    private void UpdateMultipleScoreInfoText2(int multipleValue, bool canActive = true)
    {
        _multipleScoreInfoText.gameObject.SetActive(canActive);
        _multipleScoreInfoText.text = $"x{multipleValue}";
    }

    public void ChangedPlatformMultipleScoreValue2()
    {
        int[] chances = { 15, 10, 10, 15, 50 };
        int chance = Random.Range(0, 100);

        PlatformMultipleScoreTypeEnum[] scoreEnums = {
        PlatformMultipleScoreTypeEnum.Five,
        PlatformMultipleScoreTypeEnum.Four,
        PlatformMultipleScoreTypeEnum.Three,
        PlatformMultipleScoreTypeEnum.Two,
        PlatformMultipleScoreTypeEnum.One
    };

        for (int i = 0; i < chances.Length; i++)
        {
            if (chance <= chances[i])
            {
                _platformMultipleScoreTypeEnum = scoreEnums[i];
                UpdateMultipleScoreInfoText(chances.Length - i, i < 4);
                return;
            }

            chance -= chances[i];
        }
    }
}
