using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.EnumScripts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using TMPro;
using UnityEngine;
public enum LandingTypeEnum
{
    PerfectLanding,
    NormalLanding,
    BadLanding,
    Destroy
}
namespace Assembly_CSharp.Assets.Scripts.LandingPlatformScripts.Concretes
{
    public class PlatformController : MonoBehaviour
    {

        [SerializeField] private PlatformControllerSO _platformControllerSO;
        [SerializeField] private TextMeshPro _multipleScoreInfoText;
        private PlatformMultipleScoreTypeEnum _platformScoreMultiplier;
        LandingTypeEnum _landingType;

        IPlayerFuel _playerFuel;


        private void Start()
        {
            UpdatePlatformScoreMultiplier();
            GameManager.Instance.gameStartingEvent += UpdatePlatformScoreMultiplier;
        }
        private void OnDisable()
        {
            GameManager.Instance.gameStartingEvent -= UpdatePlatformScoreMultiplier;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out PlayerController player))
            {
                float hitSpeed = CalculateImpactSpeed(other);
                HandleLanding(player, hitSpeed);
            }
        }

        private float CalculateImpactSpeed(Collision2D collision)
        {
            float verticalVelocity = Vector2.Dot(collision.relativeVelocity, Vector2.down);
            return Mathf.Abs(verticalVelocity * 100);
        }

        private void HandleLanding(PlayerController player, float hitSpeed)
        {
            _playerFuel = player.FuelController;
            player.Rigidbody2D.bodyType = RigidbodyType2D.Static;

            if (_playerFuel.IsEmpty)
            {
                CompleteLanding(hitSpeed, 0, GameManagerStateEnum.GameFinishedState);
            }
            else if (hitSpeed > _platformControllerSO.MaxLandingSpeed)
            {
                _playerFuel.UpdateGameStartingFuel(_playerFuel.GameStartingFuel - _platformControllerSO.FuelPenalty);
                CompleteLanding(hitSpeed, 0, GameManagerStateEnum.MissionFailedState);
            }
            else
            {
                _landingType = DetermineLandingType(hitSpeed);
                int totalScore = CalculateTotalScore(_landingType);
                Debug.Log(totalScore);
                player.ScoreManager.AddScore(totalScore);
                _playerFuel.UpdateGameStartingFuel(_playerFuel.CurrentFuel);
                CompleteLanding(hitSpeed, totalScore, GameManagerStateEnum.MissionCompleteState);
            }
        }

        private void CompleteLanding(float hitSpeed, int score, GameManagerStateEnum state)
        {
            UiManager.Instance.OpenLandingMissionEvent(hitSpeed, score);
            GameManager.Instance.TransitionToState(state);
        }
        private LandingTypeEnum DetermineLandingType(float hitSpeed)
        {
            if (hitSpeed >= _platformControllerSO.DetermineLandingSO.FallSpeedPerfectLanding)
            {
                return LandingTypeEnum.PerfectLanding;
            }
            else if (hitSpeed >= _platformControllerSO.DetermineLandingSO.FallSpeedNormalLanding)
            {
                return LandingTypeEnum.NormalLanding;
            }
            else if (hitSpeed >= _platformControllerSO.DetermineLandingSO.FallSpeedBadLanding)
            {
                return LandingTypeEnum.BadLanding;
            }

            return LandingTypeEnum.BadLanding;
        }
        private int CalculateTotalScore(LandingTypeEnum landingType)
        {
            int multiplier;

            if (landingType == LandingTypeEnum.PerfectLanding)
            {
                multiplier = _platformControllerSO.PerfectLandingMultiplier;
            }
            else if (landingType == LandingTypeEnum.NormalLanding)
            {
                multiplier = _platformControllerSO.NormalLandingMultiplier;
            }
            else
            {
                multiplier = _platformControllerSO.BadLandingMultiplier;
            }

            return multiplier * (int)_platformScoreMultiplier;
        }

        private void UpdatePlatformScoreMultiplier()
        {
            _platformScoreMultiplier = GetRandomPlatformMultiplierScore();
            UpdateScoreMultiplierText((int)_platformScoreMultiplier, _platformScoreMultiplier != PlatformMultipleScoreTypeEnum.One);
        }

        private void UpdateScoreMultiplierText(int multiplier, bool isActive)
        {
            _multipleScoreInfoText.gameObject.SetActive(isActive);
            _multipleScoreInfoText.text = $"x{multiplier}";
        }

        private PlatformMultipleScoreTypeEnum GetRandomPlatformMultiplierScore()
        {
            var weightedOptions = new List<(PlatformMultipleScoreTypeEnum, int)>
        {
        (PlatformMultipleScoreTypeEnum.Five, 20),
        (PlatformMultipleScoreTypeEnum.Four, 20),
        (PlatformMultipleScoreTypeEnum.Three, 20),
        (PlatformMultipleScoreTypeEnum.Two, 20),
        (PlatformMultipleScoreTypeEnum.One, 20),
        };

            int randomValue = Random.Range(0, 100);
            int cumulative = 0;

            foreach (var (scoreType, probability) in weightedOptions)
            {
                cumulative += probability;
                if (randomValue < cumulative)
                {
                    return scoreType;
                }
            }
            return PlatformMultipleScoreTypeEnum.One;
        }



    }

}