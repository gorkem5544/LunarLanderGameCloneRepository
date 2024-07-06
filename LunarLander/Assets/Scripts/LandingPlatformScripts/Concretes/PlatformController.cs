using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.EnumScripts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using TMPro;
using UnityEngine;
namespace Assembly_CSharp.Assets.Scripts.LandingPlatformScripts.Concretes
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _multipleScoreInfoText;
        private PlatformMultipleScoreTypeEnum _platformMultipleScoreTypeEnum;

        IPlayerFuel _playerFuel;


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
            _playerFuel = playerController.FuelController;
            playerController.Rigidbody2D.bodyType = RigidbodyType2D.Static;

            if (_playerFuel.IsEmpty)
            {
                UiManager.Instance.OpenLandingMissionEvent(hitSpeed, 0);
                GameManager.Instance.TransitionToState(GameManagerStateEnum.GameFinishedState);
            }
            else
            {
                if (hitSpeed > 50)
                {
                    FailedLanding(hitSpeed);
                }
                else
                {
                    SuccessfulLanding(playerController, hitSpeed);
                }
            }
        }

        private void FailedLanding(float hitSpeed)
        {
            _playerFuel.UpdateGameStartingFuel(_playerFuel.gameStartingFuel - 400);
            UiManager.Instance.OpenLandingMissionEvent(hitSpeed, 0);
            GameManager.Instance.TransitionToState(GameManagerStateEnum.MissionFailedState);
        }

        private void SuccessfulLanding(PlayerController playerController, float hitSpeed)
        {
            int totalScore = TotalScore();
            playerController.ScoreManager.AddScore(totalScore);
            _playerFuel.UpdateGameStartingFuel(_playerFuel.CurrentFuel);

            UiManager.Instance.OpenLandingMissionEvent(hitSpeed, totalScore);
            GameManager.Instance.TransitionToState(GameManagerStateEnum.MissionCompleteState);


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



    }

}