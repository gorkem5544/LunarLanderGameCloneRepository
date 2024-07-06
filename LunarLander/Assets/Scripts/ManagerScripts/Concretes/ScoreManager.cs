using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes
{
    public class ScoreManager : IScoreManager
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

}