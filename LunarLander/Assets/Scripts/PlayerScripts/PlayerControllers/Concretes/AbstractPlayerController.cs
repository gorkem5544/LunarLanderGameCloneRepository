using Assembly_CSharp.Assets.Scripts.ManagerScripts.Abstracts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Concretes;
using UnityEngine;

public abstract class AbstractPlayerController : MonoBehaviour, IBasePlayerController
{

    public Rigidbody2D Rigidbody2D => _playerRigidBody2D;
    [SerializeField] protected Rigidbody2D _playerRigidBody2D;


    protected virtual void Awake()
    {
        _playerRigidBody2D = GetComponent<Rigidbody2D>();
    }
    public virtual Vector2 PlayerVelocity => _playerRigidBody2D.linearVelocity * 100;

}
