using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Abstracts;
using UnityEngine;


namespace Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Concretes
{
    [CreateAssetMenu(fileName = "PlayerSO", menuName = "PlayerSO", order = 0)]
    public class PlayerSO : ScriptableObject, IPlayerRotateSO, IPlayerForceSO, IPlayerFuelSO
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

        [Header("Player Fuel Infos")]
        [SerializeField] private float _gameStartingFuelAmount;
        public float GameStartingFuelAmount => _gameStartingFuelAmount;

    }

}