using System;
using UnityEngine;

public class PlayerForceUpMovement
{
    private readonly GameObject _fireParticle;
    private bool _canForceUp = false;
    IPlayerForceUpMovementService _playerForceUpMovementService;

    public PlayerForceUpMovement(GameObject fireParticle, IPlayerForceUpMovementService playerForceUpMovementService)
    {
        _playerForceUpMovementService = playerForceUpMovementService;
        _fireParticle = fireParticle ?? throw new ArgumentNullException(nameof(fireParticle));
    }

    public void UpdateTick()
    {
        _canForceUp = _playerForceUpMovementService.PlayerInput.GetInput().y > 0;
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
        if (_playerForceUpMovementService.PlayerFuel.IsEmpty)
            return;

        _playerForceUpMovementService.PlayerFuel.FuelDecrease(0.15f);
        _playerForceUpMovementService.Rigidbody2D.AddRelativeForce(Vector2.up * _playerForceUpMovementService.PlayerForceSO.ForceSpeed * Time.fixedDeltaTime);

        SoundManager.Instance.PlaySound(SoundManagerTypeEnum.LaunchSound);
        _fireParticle.SetActive(true);
    }

    private void StopLaunch()
    {
        SoundManager.Instance.StopSound(SoundManagerTypeEnum.LaunchSound);
        _fireParticle.SetActive(false);
        Vector2 frictionForce = new Vector2(-_playerForceUpMovementService.Rigidbody2D.velocity.x * _playerForceUpMovementService.PlayerForceSO.FrictionCoefficient, 0f);
        _playerForceUpMovementService.Rigidbody2D.AddForce(frictionForce);
    }
}
