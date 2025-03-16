using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Concretes
{

    [CreateAssetMenu(fileName = "GameFinishedSO", menuName = "LunarLander/LandingMissionScriptableObject", order = 0)]
    public class LunaLandingMissionScenariosSO : ScriptableObject
    {
        // [Header("Finished Text")]
        // [SerializeField] private string _titleText;
        // public string TitleText { get => _titleText; set => _titleText = value; }

        // [Header("Score")]
        // [SerializeField] private int _score;
        // public int Score => _score;

        [System.Serializable]
        public class LandingMissionEntry
        {
            [SerializeField] private string _titleText;
            [SerializeField] private LandingTypeEnum _landingTypeEnum;
            [SerializeField] private int _score;

        }

        [SerializeField] private List<LandingMissionEntry> _landingEntries = new List<LandingMissionEntry>();
        public IReadOnlyList<LandingMissionEntry> LandingEntries => _landingEntries;
    }

}