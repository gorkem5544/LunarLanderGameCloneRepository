using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Abstracts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Concretes;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes
{
    public class PlayerControllerInMenu : MonoBehaviour, IBasePlayerController
    {

        protected IScoreManager _scoreManager;
        public IScoreManager ScoreManager => _scoreManager;

        public Rigidbody2D Rigidbody2D => _playerRigidbody2D;
        [SerializeField] protected Rigidbody2D _playerRigidbody2D;
        public Vector2 PlayerVelocity => _playerRigidbody2D.velocity * 100;


        private void Awake()
        {
            _playerRigidbody2D = GetComponent<Rigidbody2D>();
            _scoreManager = new ScoreManager();

        }
        private void FixedUpdate()
        {
            _playerRigidbody2D.AddForce(Vector2.right * 3 * Time.fixedDeltaTime);
        }
    }

}