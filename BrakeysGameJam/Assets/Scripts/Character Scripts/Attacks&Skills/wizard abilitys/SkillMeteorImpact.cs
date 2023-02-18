using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMeteorImpact : MonoBehaviour
{
    public  AttackAbilitys skillData;
    private HeroStats heroStats;
    public GameObject meteor;
    private int BaseDamage;


    public void GetMouseLocationPosition()
    {

    }



    public int AttackDamage()
    {
        int attack = (int)(BaseDamage * (1 + (heroStats.GetAttackDamage() / 100)));
        return attack;
    }
}
