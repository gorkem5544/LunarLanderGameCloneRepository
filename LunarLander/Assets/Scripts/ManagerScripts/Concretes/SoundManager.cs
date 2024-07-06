using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.EnumScripts;
using Assembly_CSharp.Assets.Scripts.ManagerScripts.Abstracts;
using Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Concretes;
using UnityEngine;
namespace Assembly_CSharp.Assets.Scripts.ManagerScripts.Concretes
{
    public class SoundManager : SingletonDontDestroyObject<SoundManager>
    {
        [SerializeField] private AudioSource[] _audioSources;

        public void SetVolume(SoundManagerTypeEnum soundManagerTypeEnum, float volume)
        {
            _audioSources[(int)soundManagerTypeEnum].volume = Mathf.Clamp(volume, 0.0f, 1.0f);

        }

        public void PlaySound(SoundManagerTypeEnum soundManagerTypeEnum)
        {
            if (!_audioSources[(int)soundManagerTypeEnum].isPlaying)
            {

                _audioSources[(int)soundManagerTypeEnum].Play();
            }
        }
        public void StopSound(SoundManagerTypeEnum soundManagerTypeEnum)
        {
            if (_audioSources[(int)soundManagerTypeEnum].isPlaying)
            {
                _audioSources[(int)soundManagerTypeEnum].Stop();
            }
        }
    }

}