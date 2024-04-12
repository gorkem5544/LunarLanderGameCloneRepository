using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerInMenu : AbstractPlayerController
{

    private void FixedUpdate()
    {
        _playerRigidbody2D.AddForce(Vector2.right * 3 * Time.fixedDeltaTime);
    }
}
public abstract class AbstractPlayerController : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _playerRigidbody2D;
    public Vector2 PlayerVelocity()
    {
        return _playerRigidbody2D.velocity * 100;
    }
}