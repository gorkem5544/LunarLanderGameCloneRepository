using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Concretes
{
    [CreateAssetMenu(fileName = "CameraScriptableObject", menuName = "CameraScriptableObject", order = 0)]
    public class CameraScriptableObject : ScriptableObject
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _closeZoom = 1f;
        [SerializeField] private float _zoomSpeed = 5f;
        [SerializeField] private float _groundDistance = 150f;

        public LayerMask GroundLayer { get => _groundLayer; set => _groundLayer = value; }
        public float CloseZoom { get => _closeZoom; set => _closeZoom = value; }
        public float ZoomSpeed { get => _zoomSpeed; set => _zoomSpeed = value; }
        public float GroundDistance { get => _groundDistance; set => _groundDistance = value; }
    }
}