using UnityEngine;

public class DistanceCalculator : IDistanceCalculator
{
    private Transform _playerTransform;
    private LayerMask _groundLayer;

    public DistanceCalculator(Transform playerTransform, LayerMask groundLayer)
    {
        _playerTransform = playerTransform;
        _groundLayer = groundLayer;
    }

    public float CalculateDistanceToGround()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(_playerTransform.position, Vector2.down, 1000, _groundLayer);
        if (raycastHit2D.collider != null)
        {
            return raycastHit2D.distance * 100;
        }
        return -1;
    }
}
