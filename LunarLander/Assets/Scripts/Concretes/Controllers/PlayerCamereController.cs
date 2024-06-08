using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamereController : MonoBehaviour
{
    PlayerController _playerController;
    private void Awake()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }
    private void Update()
    {

    }
}
