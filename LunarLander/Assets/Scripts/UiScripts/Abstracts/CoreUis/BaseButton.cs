using UnityEngine;
using UnityEngine.UI;

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