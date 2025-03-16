using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalSpeedIcon : BaseSpeedIcon
{
    protected override void UpdateSpeedIcon()
    {
        float rotationAngle = (playerController.PlayerVelocity.y >= 0) ? 180f : 0f;
        speedIcon.transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, rotationAngle);
    }
}