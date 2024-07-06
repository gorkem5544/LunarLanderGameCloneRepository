using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes;
using UnityEngine.Events;

public class MenuSceneGameStartButton : BaseButton
{
    protected override void HandleOnButtonClicked()
    {
        LevelManager.Instance.LoadGame2();
    }

}
