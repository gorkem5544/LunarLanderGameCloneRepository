using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuSceneGameStartButton : BaseButton
{
    protected override void HandleOnButtonClicked()
    {
        LevelManager.Instance.LoadGame();
    }

}
public abstract class BaseButton : MonoBehaviour
{
    [SerializeField] protected Button _button;
    private void OnEnable()
    {
        _button.onClick.AddListener(HandleOnButtonClicked);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(HandleOnButtonClicked);
    }

    protected abstract void HandleOnButtonClicked();


}