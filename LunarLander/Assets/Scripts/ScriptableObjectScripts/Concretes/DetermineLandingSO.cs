using UnityEngine;

[CreateAssetMenu(fileName = "DetermineLandingSO", menuName = "Scriptable Objects/DetermineLandingSO")]
public class DetermineLandingSO : ScriptableObject, IDetermineLandingSO
{
    [SerializeField] private float _fallSpeedPerfectLanding;
    [SerializeField] private float _fallSpeedNormalLanding;
    [SerializeField] private float _fallSpeedBadLanding;
    [SerializeField] private float _fallSpeedDestroyLanding;


    public float FallSpeedPerfectLanding { get => _fallSpeedPerfectLanding; set => _fallSpeedPerfectLanding = value; }
    public float FallSpeedNormalLanding { get => _fallSpeedNormalLanding; set => _fallSpeedNormalLanding = value; }
    public float FallSpeedBadLanding { get => _fallSpeedBadLanding; set => _fallSpeedBadLanding = value; }
    public float FallSpeedDestroyLanding { get => _fallSpeedDestroyLanding; set => _fallSpeedDestroyLanding = value; }

}
public interface IDetermineLandingSO
{
    public float FallSpeedPerfectLanding { get; }
    public float FallSpeedNormalLanding { get; }
    public float FallSpeedBadLanding { get; }
    public float FallSpeedDestroyLanding { get; }

}