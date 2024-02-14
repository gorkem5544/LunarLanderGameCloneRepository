using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SoundManagerTypeEnum
{
    LaunchSound, GameSound, MenuSound
}
public class SoundManager : SingletonDontDestroyObject<SoundManager>
{
    [SerializeField] private AudioSource[] _audioSources;
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
