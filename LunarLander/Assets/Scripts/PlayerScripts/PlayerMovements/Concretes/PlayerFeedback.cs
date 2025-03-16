using Assembly_CSharp.Assets.Scripts.EnumScripts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes;
using Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Concretes
{
    public class PlayerFeedback : IPlayerFeedback
    {
        private readonly GameObject _fireParticle;

        public PlayerFeedback(GameObject fireParticle)
        {
            _fireParticle = fireParticle;
        }

        public void PlayLaunchSound()
        {
            //SoundManager.Instance.PlaySound(SoundManagerTypeEnum.LaunchSound);
        }

        public void StopLaunchSound()
        {
            //SoundManager.Instance.StopSound(SoundManagerTypeEnum.LaunchSound);
        }

        public void ActivateFireParticle()
        {
            _fireParticle.SetActive(true);
        }

        public void DeactivateFireParticle()
        {
            _fireParticle.SetActive(false);
        }
    }

}