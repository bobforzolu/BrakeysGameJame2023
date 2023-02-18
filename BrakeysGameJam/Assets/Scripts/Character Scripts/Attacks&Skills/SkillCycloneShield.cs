using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class SkillCycloneShield : MonoBehaviour
{
    public DurationSkills skilldata;
    private HeroStats heroStats;
    public GameObject cyclone;
    private int BaseDamage;
    private DamageOverTimeTimer damageOverTime;
    public bool isSkillactive { get; private set; }
    void Start()
    {
        BaseDamage = skilldata.Damage;
        damageOverTime = GetComponentInChildren<DamageOverTimeTimer>();
    }
    public void ActivateSkill()
    {
        if(!isSkillactive)
        {
            isSkillactive= true;
            cyclone.SetActive(true);
            damageOverTime.SetHeroStats(heroStats);
            damageOverTime.SetTimers();

        }
    }
    public int AttackDamage()
    {
        int attack = (int)(BaseDamage * ( 1 + (heroStats.GetAttackDamage() / 100)));
        return attack;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSkillactive)
        {
            cyclone.GetComponentInChildren<HitBoxDetection>().UpdateDamage(AttackDamage());

        }
        
        if(!cyclone.activeInHierarchy)
        {
            isSkillactive= false;
        }
        
    }
   
    public void SetHeroData(HeroStats heroStats)
    {
        this.heroStats = heroStats;
       

    }
}
