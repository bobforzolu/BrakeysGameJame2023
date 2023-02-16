using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Auto attack Data", menuName = "Character/ Auto Attack Data")]
public class AutoAttackData : ScriptableObject
{
    public float AttackInterval;
    public int Damage;
    public float ProjectileSpeed;
    public int ProjectileAmount;
}
