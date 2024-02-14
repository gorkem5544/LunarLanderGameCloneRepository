using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonDontDestroyObject<GameManager>
{

    public event System.Action<float, int> MissionCompleteEvent;

    public bool GameFinished { get; set; }

    public void MissionComplete(float playerVelocityY, int score)
    {
        MissionCompleteEvent?.Invoke(playerVelocityY, score);
        GameFinished = true;
    }
}

public abstract class SingletonDontDestroyObject<T> : MonoBehaviour where T : class
{
    public static T Instance { get; private set; }
    protected virtual void Awake()
    {
        SetSingleton();
    }
    protected virtual void SetSingleton()
    {
        if (Instance == null)
        {
            Instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
