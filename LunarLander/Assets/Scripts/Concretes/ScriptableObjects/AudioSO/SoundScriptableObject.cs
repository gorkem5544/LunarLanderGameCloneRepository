using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundScriptableObject", menuName = "SoundScriptableObject", order = 0)]
public class SoundScriptableObject : ScriptableObject {
      [SerializeField] private SoundManagerTypeEnum _soundManagerTypeEnum;

    public SoundManagerTypeEnum SoundManagerTypeEnum { get => _soundManagerTypeEnum; set => _soundManagerTypeEnum = value; }
    public AudioSource AudioClip { get => _audioClip; set => _audioClip = value; }

    [SerializeField] private AudioSource _audioClip;
}