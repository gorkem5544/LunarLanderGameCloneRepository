
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Abstracts;
using TMPro;
using UnityEngine;

public class ScoreUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private IPlayerController _playerController;

    public void Initialize(IPlayerController playerController)
    {
        _playerController = playerController;
    }
    private void Start()
    {
        UpdateScoreText(0000);
        _playerController.ScoreManager.ScoreChanged += UpdateScoreText;
    }
    private void OnDisable()
    {
        _playerController.ScoreManager.ScoreChanged -= UpdateScoreText;

    }
    private void UpdateScoreText(int score = 0000)
    {
        _scoreText.text = $"SCORE: {score}";

    }
}

