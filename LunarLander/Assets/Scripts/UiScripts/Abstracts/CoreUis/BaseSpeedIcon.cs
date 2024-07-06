using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerControllers.Concretes;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSpeedIcon : MonoBehaviour
{
    [SerializeField] protected Image speedIcon;
    protected IBasePlayerController playerController;
    protected Vector3 eulerAngles;

    public void Initialize(IBasePlayerController abstractPlayerController)
    {
        playerController = abstractPlayerController;
    }

    protected virtual void Start()
    {
        eulerAngles = speedIcon.transform.eulerAngles;
    }

    protected virtual void Update()
    {
        if (playerController != null)
        {
            UpdateSpeedIcon();
        }
    }

    protected abstract void UpdateSpeedIcon();
}