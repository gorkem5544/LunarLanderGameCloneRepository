using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes
{
    public class PlayerManager : SingletonDontDestroyObject<PlayerManager>
    {
        public AbstractPlayerController PlayerController { get; private set; }
        public void InitializePlayerController(AbstractPlayerController playerController)
        {
            PlayerController = playerController;
        }
    }

}