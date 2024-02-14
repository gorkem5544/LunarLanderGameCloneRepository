using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
enum PlatformMultipleTypeEnum
{
    Five, Four, Three, Two, One
}
public class PlatformController : MonoBehaviour
{
    [SerializeField] private GameFinishedSO[] _gameFinishedSOs;
    [SerializeField] private TextMeshPro _multipleScoreInfoText;
    private PlatformMultipleTypeEnum _platformMultipleTypeEnum;
    [SerializeField] private PlatformMultipleTypeEnum platformMultipleTypeEnum;
    internal PlatformMultipleTypeEnum PlatformMultipleTypeEnum { get => _platformMultipleTypeEnum; set => _platformMultipleTypeEnum = value; }
    private void Start()
    {
        int chance = Random.Range(0, 100);
        if (chance <= 15)
        {
            _platformMultipleTypeEnum = PlatformMultipleTypeEnum.Five;
            UpdateMultipleScoreInfoText(5, true);
        }
        else if (chance <= 25)
        {
            _platformMultipleTypeEnum = PlatformMultipleTypeEnum.Four;
            UpdateMultipleScoreInfoText(4, true);

        }
        else if (chance <= 35)
        {
            _platformMultipleTypeEnum = PlatformMultipleTypeEnum.Three;
            UpdateMultipleScoreInfoText(3, true);

        }
        else if (chance <= 50)
        {
            _platformMultipleTypeEnum = PlatformMultipleTypeEnum.Two;
            UpdateMultipleScoreInfoText(2, true);
        }
        else
        {
            _platformMultipleTypeEnum = PlatformMultipleTypeEnum.One;
            UpdateMultipleScoreInfoText(1, false);
        }
        platformMultipleTypeEnum = _platformMultipleTypeEnum;
        Debug.Log(_platformMultipleTypeEnum);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out PlayerController playerController))
        {
            GameManager.Instance.MissionComplete(playerController.PlayerVelocity().y, TotalScore());
            playerController.ScoreManager.AddScore(TotalScore());
        }
    }
    public int TotalScore()
    {
        int score = 50;
        switch (_platformMultipleTypeEnum)
        {
            case PlatformMultipleTypeEnum.One:
                score *= 1;
                break;
            case PlatformMultipleTypeEnum.Two:
                score *= 2;
                break;
            case PlatformMultipleTypeEnum.Three:
                score *= 3;
                break;
            case PlatformMultipleTypeEnum.Four:
                score *= 4;
                break;
            case PlatformMultipleTypeEnum.Five:
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
}
