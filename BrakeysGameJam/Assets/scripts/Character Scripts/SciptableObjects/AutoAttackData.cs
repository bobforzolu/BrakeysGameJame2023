using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Auto attack Data", menuName = "Character/ Auto Attack Data")]
public class AutoAttackData : ScriptableObject
{
    public float DeacresAutoattackCooldown;
    public float AutoattackCoolDown;
    public int Damage;
    public float ProjectileSpeed;
    public int ProjectileAmount;
}
