using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerSO", menuName = "PlayerSO", order = 0)]
public class PlayerSO : ScriptableObject, IPlayerRotateSO, IPlayerForceSO
{
    [Header("Force Infos")]
    [SerializeField] private float _forceSpeed;
    public float ForceSpeed => _forceSpeed;
    [SerializeField] private float _frictionCoefficient;
    public float FrictionCoefficient => _frictionCoefficient;


    [Header("Player Rotate Infos")]
    [SerializeField] private float _rotationSpeed;
    public float RotationSpeed => _rotationSpeed;
    [SerializeField] private float _rotationLimit;
    public float RotationLimit => _rotationLimit;

}

public interface IPlayerRotateSO
{
    public float RotationSpeed { get; }
    public float RotationLimit { get; }
}
public interface IPlayerForceSO
{
    public float ForceSpeed { get; }
    public float FrictionCoefficient { get; }
}