using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreManager
{
    void AddScore(int amount, int multipleValue = 1);
    void AddDeadScore(int amount);
    void AddDefaultScore(int amount);
    int Score { get; }
    System.Action<int> ScoreChanged { get; set; }
}
public class ScoreManager : MonoBehaviour, IScoreManager
{
    private int _currentScore;
    public int Score => _currentScore;
    public Action<int> ScoreChanged { get; set; }

    public void AddDeadScore(int amount)
    {
        _currentScore += amount;
    }

    public void AddDefaultScore(int amount = 50)
    {
        _currentScore += amount;
    }

    public void AddScore(int amount, int multipleValue = 1)
    {
        _currentScore += amount * multipleValue;
        ScoreChanged?.Invoke(_currentScore);
    }
}
