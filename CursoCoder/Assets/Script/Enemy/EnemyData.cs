using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Create EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

    public int dmg;
    public int hp;
    public float rayDistance = 20f;
    public float secondRayDistance = 2f;
    public float lerpSmoothness;

}
