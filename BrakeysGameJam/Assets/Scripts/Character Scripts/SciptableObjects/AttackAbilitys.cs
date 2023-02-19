using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage  data", menuName = "Character/ skilll /Damage abilitys")]

public class AttackAbilitys: ScriptableObject
{
    public int Damage;
    public float SkillConsumption;
    public float speed;
}
