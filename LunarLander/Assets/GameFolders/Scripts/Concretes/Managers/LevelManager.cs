using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assembly_CSharp.Assets.Scripts.EnumScripts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Abstracts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes
{
    public class LevelManager : SingletonDontDestroyObject<LevelManager>
    {
        public void LoadMenu()
        {
            StartCoroutine(LoadLevelAsync());
            GameManager.Instance.TransitionToState(GameManagerStateEnum.MenuState);
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
        public async void LoadGame2()
        {
            await LoadGameLevelAsync2();
            GameManager.Instance.TransitionToState(GameManagerStateEnum.GameInState);
        }

        private async Task LoadGameLevelAsync2()
        {
            // Asenkron olarak sahneyi yükle
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");

            // Yükleme tamamlanana kadar bekle
            while (!asyncLoad.isDone)
            {
                // Yükleme ilerlemesini takip etmek için burada bir şeyler yapabilirsiniz
                await Task.Yield(); // Unity'nin ana döngüsüne dönmek için bir kare bekle
            }
        }
    }

}