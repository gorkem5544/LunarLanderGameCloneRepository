using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Concretes
{

    [CreateAssetMenu(fileName = "GameFinishedSO", menuName = "LunarLander/GameFinishedSO", order = 0)]
    public class LunaLandingMissionScenariosSO : ScriptableObject
    {
        [SerializeField] private string _titleText;
        public string TitleText { get => _titleText; set => _titleText = value; }

    }

}