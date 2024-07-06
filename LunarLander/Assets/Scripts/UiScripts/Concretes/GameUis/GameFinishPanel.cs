using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Concretes;
using TMPro;
using UnityEngine;

public class GameFinishPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _headText;
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void Init(LunaLandingMissionScenariosSO gameFinishedSO, int score)
    {
        _headText.text = gameFinishedSO.TitleText;
        _scoreText.text = $"{score} Score";
    }
}
