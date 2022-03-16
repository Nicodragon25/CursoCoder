using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "playerData", menuName = "Create PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private float speed;
    public float Speed{get{ return speed; }}

    [SerializeField] private float hp;
    public float HP { get{ return hp; }  set { hp = value; } }

    [SerializeField] private int score = 0;
    public int Score { get{ return score; } set{ score = value; } }
}
