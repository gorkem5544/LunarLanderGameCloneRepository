using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "GameFinishedSO", menuName = "LunarLander/GameFinishedSO", order = 0)]
public class GameFinishedSO : ScriptableObject
{
    [SerializeField] private string _headInfo;
    public string HeadInfo { get => _headInfo; set => _headInfo = value; }

}
