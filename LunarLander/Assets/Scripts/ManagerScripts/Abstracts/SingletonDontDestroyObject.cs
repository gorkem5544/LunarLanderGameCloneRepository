using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.ManagerScripts.Abstracts
{
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

}