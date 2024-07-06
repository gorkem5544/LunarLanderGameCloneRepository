using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.ScriptableObjectScripts.Concretes
{
  [CreateAssetMenu(fileName = "SoundScriptableObject", menuName = "SoundScriptableObject", order = 0)]
  public class SoundScriptableObject : ScriptableObject
  {
    public AudioClip AudioClip;
  }
}