using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private GameSoundData soundData;

    private Dictionary<GameSoundTypeEnum, AudioSource> _audioSources;
    private const string VOLUME_PREFS_KEY = "SoundVolume_{0}";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeAudio();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeAudio()
    {
        if (soundData == null)
        {
            Debug.LogError("GameSoundData is not assigned to SoundManager!");
            return;
        }

        _audioSources = new Dictionary<GameSoundTypeEnum, AudioSource>();

        foreach (var entry in soundData.SoundEntries)
        {
            CreateAudioSource(entry);
        }

        // İlk ses seviyelerini ayarla
        foreach (AudioCategoryEnum category in System.Enum.GetValues(typeof(AudioCategoryEnum)))
        {
            float savedVolume = GetSavedVolume(category);
            UpdateCategoryVolume(category, savedVolume);
        }
    }

    private void CreateAudioSource(GameSoundData.SoundEntry entry)
    {
        var sourceObj = new GameObject($"AudioSource_{entry.soundType}");
        sourceObj.transform.SetParent(transform);

        var source = sourceObj.AddComponent<AudioSource>();
        ConfigureAudioSource(source, entry);

        _audioSources[entry.soundType] = source;
    }

    private void ConfigureAudioSource(AudioSource source, GameSoundData.SoundEntry entry)
    {
        source.clip = entry.clip;
        source.loop = entry.loop;
        source.playOnAwake = false;
        source.volume = GetSavedVolume(entry.category) * entry.defaultVolume;
    }

    public void PlaySound(GameSoundTypeEnum soundType, bool allowOverlap = false)
    {
        if (_audioSources.TryGetValue(soundType, out AudioSource source))
        {
            if (allowOverlap)
            {
                source.PlayOneShot(source.clip);
            }
            else if (!source.isPlaying)
            {
                source.Play();
            }
        }
        else
        {
            Debug.LogWarning($"Sound not found: {soundType}");
        }
    }

    public void StopSound(GameSoundTypeEnum soundType)
    {
        if (_audioSources.TryGetValue(soundType, out AudioSource source))
        {
            source.Stop();
        }
    }

    public void StopAllSounds()
    {
        foreach (var source in _audioSources.Values)
        {
            source.Stop();
        }
    }

    public void SetVolume(AudioCategoryEnum category, float volume)
    {
        volume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat(string.Format(VOLUME_PREFS_KEY, category), volume);
        UpdateCategoryVolume(category, volume);
    }

    private void UpdateCategoryVolume(AudioCategoryEnum category, float volume)
    {
        foreach (var entry in soundData.SoundEntries)
        {
            if (entry.category == category && _audioSources.TryGetValue(entry.soundType, out AudioSource source))
            {
                source.volume = volume * entry.defaultVolume;
            }
        }
    }

    public float GetVolume(AudioCategoryEnum category)
    {
        return GetSavedVolume(category);
    }

    private float GetSavedVolume(AudioCategoryEnum category)
    {
        return PlayerPrefs.GetFloat(string.Format(VOLUME_PREFS_KEY, category), 1f);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}