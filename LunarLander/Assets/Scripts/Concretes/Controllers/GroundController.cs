using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            
        }
    }
}
