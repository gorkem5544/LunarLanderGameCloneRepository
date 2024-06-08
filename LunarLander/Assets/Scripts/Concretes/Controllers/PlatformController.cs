using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
enum PlatformMultipleScoreTypeEnum
{
    Five = 5,
    Four = 4,
    Three = 3,
    Two = 2,
    One = 1
}
public enum LandingMissionTypeEnum
{
    PerfectLanding, HardLanding, FailedLanding
}
public class PlatformController : MonoBehaviour
{
    [SerializeField] private TextMeshPro _multipleScoreInfoText;
    private PlatformMultipleScoreTypeEnum _platformMultipleScoreTypeEnum;

    PlayerFuel _playerFuel;


    private void Start()
    {
        ChangedPlatformMultipleScoreValue();
        GameManager.Instance.gameStartingEvent += ChangedPlatformMultipleScoreValue;
    }

    private void OnDisable()
    {
        GameManager.Instance.gameStartingEvent -= ChangedPlatformMultipleScoreValue;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out PlayerController playerController))
        {
            HandleCollision(playerController, other.relativeVelocity.magnitude * 100);
        }
    }

    private void HandleCollision(PlayerController playerController, float hitSpeed)
    {
        int totalScore = TotalScore();
        UiManager.Instance.OpenLandingMissionEvent(hitSpeed, totalScore);
        playerController.ScoreManager.AddScore(totalScore);
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
    public int TotalScore()
    {
        return 50 * (int)_platformMultipleScoreTypeEnum;
    }
    private void UpdateMultipleScoreInfoText(int multipleValue, bool canActive = true)
    {
        _multipleScoreInfoText.gameObject.SetActive(canActive);
        _multipleScoreInfoText.text = $"x{multipleValue}";
    }
    public void ChangedPlatformMultipleScoreValue()
    {
        _platformMultipleScoreTypeEnum = GetRandomPlatformScore();
        UpdateMultipleScoreInfoText((int)_platformMultipleScoreTypeEnum, _platformMultipleScoreTypeEnum != PlatformMultipleScoreTypeEnum.One);
    }

    private PlatformMultipleScoreTypeEnum GetRandomPlatformScore()
    {
        int chance = Random.Range(0, 100);
        if (chance <= 15) return PlatformMultipleScoreTypeEnum.Five;
        if (chance <= 25) return PlatformMultipleScoreTypeEnum.Four;
        if (chance <= 35) return PlatformMultipleScoreTypeEnum.Three;
        if (chance <= 50) return PlatformMultipleScoreTypeEnum.Two;
        return PlatformMultipleScoreTypeEnum.One;
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
