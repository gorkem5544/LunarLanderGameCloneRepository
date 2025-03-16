using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSoundData", menuName = "Audio/Game Sound Data")]
public class GameSoundData : ScriptableObject
{
    [System.Serializable]
    public class SoundEntry
    {
        public GameSoundTypeEnum soundType;
        public AudioClip clip;
        public AudioCategoryEnum category;
        [Range(0f, 1f)]
        public float defaultVolume = 1f;
        public bool loop;
    }

    [SerializeField] private List<SoundEntry> soundEntries = new List<SoundEntry>();
    public IReadOnlyList<SoundEntry> SoundEntries => soundEntries;
}
