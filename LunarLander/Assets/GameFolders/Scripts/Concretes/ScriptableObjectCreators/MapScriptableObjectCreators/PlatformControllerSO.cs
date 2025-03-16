using UnityEngine;

[CreateAssetMenu(fileName = "PlatformControllerSO", menuName = "Scriptable Objects/PlatformControllerSO")]
public class PlatformControllerSO : ScriptableObject, IPlatformControllerSO
{
    [Header("Base Score Infos")]
    [SerializeField] private int _baseScore = 50;
    public int BaseScore { get => _baseScore; set => _baseScore = value; }

    [Header("Max Landing Speed Infos")]
    [SerializeField] float _maxLandingSpeed = 50;
    public float MaxLandingSpeed { get => _maxLandingSpeed; set => _maxLandingSpeed = value; }

    [Header("Fuel Penalty Infos")]
    [SerializeField] int _fuelPenalty = 400;
    public int FuelPenalty { get => _fuelPenalty; set => _fuelPenalty = value; }

    [Header("Landing Multiplier Infos")]
    [SerializeField] private int _perfectLandingMultiplier;
    public int PerfectLandingMultiplier => _perfectLandingMultiplier;
    [SerializeField] private int _normalLandingMultiplier;
    public int NormalLandingMultiplier => _normalLandingMultiplier;
    [SerializeField] private int _badLandingMultiplier;
    public int BadLandingMultiplier => _badLandingMultiplier;

    [Header("DetermineLanding Infos")]
    [SerializeField] private DetermineLandingSO determineLandingSO;
    public DetermineLandingSO DetermineLandingSO => determineLandingSO;
}
interface IPlatformControllerSO
{
    int BaseScore { get; }
    float MaxLandingSpeed { get; }
    int FuelPenalty { get; }

    int PerfectLandingMultiplier { get; }
    int NormalLandingMultiplier { get; }
    int BadLandingMultiplier { get; }

    DetermineLandingSO DetermineLandingSO { get; }


}