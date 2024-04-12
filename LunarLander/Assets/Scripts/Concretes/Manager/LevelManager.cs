using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : SingletonDontDestroyObject<LevelManager>
{
    public void LoadMenu()
    {
        StartCoroutine(LoadLevelAsync());
    }

    private IEnumerator LoadLevelAsync()
    {
        yield return SceneManager.LoadSceneAsync("Menu");
    }
    public void LoadGame()
    {
        StartCoroutine(LoadGameLevelAsync());
    }

    private IEnumerator LoadGameLevelAsync()
    {
        yield return SceneManager.LoadSceneAsync("Game");
    }
}
