using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SoundManagerTypeEnum
{
    LaunchSound, GameSound, MenuSound
}
public class SoundManager : SingletonDontDestroyObject<SoundManager>
{
    [SerializeField] private SoundScriptableObject[] _soundScriptableObjects;
    

    public void PlaySound(SoundManagerTypeEnum soundManagerTypeEnum)
    {
        SoundScriptableObject soundObject = _soundScriptableObjects[(int)soundManagerTypeEnum];
        if (soundObject != null && !soundObject.AudioClip.isPlaying)
        {
            soundObject.AudioClip.Play();
        }
    }

    public void StopSound(SoundManagerTypeEnum soundManagerTypeEnum)
    {
        SoundScriptableObject soundObject = _soundScriptableObjects[(int)soundManagerTypeEnum];
        if (soundObject != null && soundObject.AudioClip.isPlaying)
        {
            soundObject.AudioClip.Stop();
        }
    }

}
