using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.Uis.GameUis.Icons
{
    public class HorizontalSpeedIcon : BaseSpeedIcon
    {
        protected override void UpdateSpeedIcon()
        {
            float rotationAngle = (playerController.PlayerVelocity.x >= 0) ? 90f : -90f;
            speedIcon.transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, rotationAngle);
        }
    }

}