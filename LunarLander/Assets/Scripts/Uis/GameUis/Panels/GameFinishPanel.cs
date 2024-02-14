using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameFinishPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _headText;
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void Init(GameFinishedSO gameFinishedSO, int score)
    {
        _headText.text = gameFinishedSO.HeadInfo;
        _scoreText.text = $"{score} Score";
    }
}
