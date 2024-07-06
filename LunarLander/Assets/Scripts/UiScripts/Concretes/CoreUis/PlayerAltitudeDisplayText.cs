using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes;
using TMPro;
using UnityEngine;

public class PlayerAltitudeDisplayText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _altitudeDisplayText;
    [SerializeField] private LayerMask _groundLayer;
    IDistanceCalculator _distanceCalculator;
    IBasePlayerController _basePlayerController;

    public void Initialize(IBasePlayerController abstractPlayerController)
    {
        _basePlayerController = abstractPlayerController;
        _distanceCalculator = new DistanceCalculator(abstractPlayerController.transform, _groundLayer);
    }
    private void LateUpdate()
    {
        if (_basePlayerController != null)
        {
            float altitude = _distanceCalculator.CalculateDistanceToGround();
            _altitudeDisplayText.text = $"ALTITUDE: {altitude:0.0}";
        }

    }
}
