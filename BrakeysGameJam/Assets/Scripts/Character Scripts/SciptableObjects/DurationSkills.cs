using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Damage over time data",menuName = "Character/ skilll /Damage Over Time ")]
public class DurationSkills : ScriptableObject
{
    public float skillDuration;
    public float attackInterval;
    public float maxDuration;
    public float maxAttackInterval;
    public int Damage;
    public int EnergyConsumption;

}
