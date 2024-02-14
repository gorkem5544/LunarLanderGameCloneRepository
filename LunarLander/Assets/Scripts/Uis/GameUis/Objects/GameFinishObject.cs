using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishObject : MonoBehaviour
{
    [SerializeField] private GameFinishPanel _gameFinishPanel;
    [SerializeField] private GameFinishedSO[] _gameFinishedSOs;


    private void Start()
    {
        UpdateGameFinishObjectActive(false);

        GameManager.Instance.MissionCompleteEvent += GameFinished;

    }

    private void GameFinished(float playerVelocityY, int score)
    {
        if (playerVelocityY > 0 || playerVelocityY > -5)
        {
            OpenGameFinishedPanel(_gameFinishedSOs[0], score);
        }
        else if (playerVelocityY < -15)
        {
            OpenGameFinishedPanel(_gameFinishedSOs[1], score - 25);
        }
        else
        {
            OpenGameFinishedPanel(_gameFinishedSOs[2], 25);
        }
    }

    private void OnDisable()
    {
        GameManager.Instance.MissionCompleteEvent -= GameFinished;
    }
    private void OpenGameFinishedPanel(GameFinishedSO sO, int score)
    {
        _gameFinishPanel.Init(sO, score);
        UpdateGameFinishObjectActive(true);
    }

    private void UpdateGameFinishObjectActive(bool canActive)
    {
        _gameFinishPanel.gameObject.SetActive(canActive);
    }
}
