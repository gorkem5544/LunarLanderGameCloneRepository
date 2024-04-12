
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private PlayerController _playerController;
    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }
    private void Start()
    {

        _playerController.ScoreManager.ScoreChanged += UpdateScoreText;
    }
    private void OnDisable()
    {
        _playerController.ScoreManager.ScoreChanged -= UpdateScoreText;

    }
    private void UpdateScoreText(int score = 0000)
    {
        _scoreText.text = $"SCORE {score}";

    }
}

public abstract class AbstractTextUi : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _text;

}
