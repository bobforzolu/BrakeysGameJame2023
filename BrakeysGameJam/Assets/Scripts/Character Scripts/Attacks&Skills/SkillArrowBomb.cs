using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class SkillArrowBomb : MonoBehaviour
{
    public GameObject ArrowBobPrefab;
    private HeroStats heroStats;
    [SerializeField]private int baseAttack = 10;
    public bool CanSpawnBomb { get; private set; }
    public event EventHandler OnArrowTrigger;
    private float InitalSpawnChance = 0.5f;
    private float SpawnChanceModifier = 0.002f;
    private void Start()
    {
    }

    
    public bool SpawnSkillChance()
    {
        if(UnityEngine.Random.value > (InitalSpawnChance + (SpawnChanceModifier * heroStats.GetAttackDamage())) )
        {
            return true;
        }
        else
        {
            return false;
        }
            
    }
    public int AttackDamage()
    {
        int attack = (int)baseAttack * (2 + (heroStats.GetAttackDamage() / 100));
        return attack;
    }
    public void SetHerodata(HeroStats heroStats)
    {
        this.heroStats= heroStats;
    }
    private void OnDisable()
    {
    }
}
