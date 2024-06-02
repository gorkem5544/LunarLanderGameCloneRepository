using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundScriptableObject", menuName = "SoundScriptableObject", order = 0)]
public class SoundScriptableObject : ScriptableObject
{
  public AudioClip AudioClip;
}