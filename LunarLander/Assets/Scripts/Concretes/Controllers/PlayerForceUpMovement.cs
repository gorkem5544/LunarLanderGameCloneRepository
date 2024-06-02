using UnityEngine;

public class PlayerForceUpMovement
{
    private readonly Rigidbody2D _playerRigidbody2D;
    private readonly PlayerInput _playerInput;
    private readonly PlayerFuel _fuelController;
    private readonly GameObject _fireParticle;
    private readonly float _forceSpeed;
    private readonly float _frictionCoefficient = 0.1f;

    private bool _canForceUp = false;

    public PlayerForceUpMovement(Rigidbody2D playerRigidbody2D, PlayerInput playerInput, float forceSpeed, PlayerFuel fuelController, GameObject fireParticle)
    {
        _playerRigidbody2D = playerRigidbody2D;
        _playerInput = playerInput;
        _forceSpeed = forceSpeed;
        _fuelController = fuelController;
        _fireParticle = fireParticle;
    }
    public void UpdateTick()
    {
        _canForceUp = _playerInput.GetInput().y > 0;
    }

    public void FixedTick()
    {
        if (_canForceUp)
        {
            ApplyForceUp();
        }
        else
        {
            StopLaunch();
        }
    }

    private void ApplyForceUp()
    {
        if (_fuelController.IsEmpty)
            return;

        _fuelController.FuelDecrease(0.15f);
        _playerRigidbody2D.AddRelativeForce(Vector2.up * _forceSpeed * Time.fixedDeltaTime);

        SoundManager.Instance.PlaySound(SoundManagerTypeEnum.LaunchSound);
        _fireParticle.SetActive(true);
    }

    private void StopLaunch()
    {
        SoundManager.Instance.StopSound(SoundManagerTypeEnum.LaunchSound);
        _fireParticle.SetActive(false);
        Vector2 frictionForce = new Vector2(-_playerRigidbody2D.velocity.x * _frictionCoefficient, 0f);
        _playerRigidbody2D.AddForce(frictionForce);
    }

}
