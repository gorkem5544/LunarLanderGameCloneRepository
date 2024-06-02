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
    private Dictionary<SoundManagerTypeEnum, AudioSource> _audioSources;

    protected override void Awake()
    {
        base.Awake();
        _audioSources = new Dictionary<SoundManagerTypeEnum, AudioSource>();
        foreach (SoundManagerTypeEnum soundType in System.Enum.GetValues(typeof(SoundManagerTypeEnum)))
        {
            SoundScriptableObject soundObject = _soundScriptableObjects[(int)soundType];
            if (soundObject != null)
            {
                GameObject audioSourceObject = new GameObject(soundType.ToString() + "AudioSource");
                audioSourceObject.transform.SetParent(this.transform);
                AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
                audioSource.clip = soundObject.AudioClip;
                _audioSources[soundType] = audioSource;
            }
        }
    }

    public void PlaySound(SoundManagerTypeEnum soundManagerTypeEnum)
    {
        if (_audioSources.TryGetValue(soundManagerTypeEnum, out AudioSource audioSource))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    public void StopSound(SoundManagerTypeEnum soundManagerTypeEnum)
    {
        if (_audioSources.TryGetValue(soundManagerTypeEnum, out AudioSource audioSource))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
    public void SetVolume(SoundManagerTypeEnum soundManagerTypeEnum, float volume)
    {
        if (_audioSources.TryGetValue(soundManagerTypeEnum, out AudioSource audioSource))
        {
            audioSource.volume = Mathf.Clamp(volume, 0.0f, 1.0f); // 0 ile 1 arasında ses seviyesi
        }
    }
    public void RemoveSound(SoundManagerTypeEnum soundManagerTypeEnum)
    {
        if (_audioSources.TryGetValue(soundManagerTypeEnum, out AudioSource audioSource))
        {
            Destroy(audioSource.gameObject);
            _audioSources.Remove(soundManagerTypeEnum);
        }
    }

}
public interface ISoundService
{
    void PlaySound(SoundManagerTypeEnum soundManagerTypeEnum);
    void StopSound(SoundManagerTypeEnum soundManagerTypeEnum);
}