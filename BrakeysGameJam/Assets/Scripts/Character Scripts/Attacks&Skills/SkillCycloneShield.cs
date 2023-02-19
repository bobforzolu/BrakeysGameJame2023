using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class SkillCycloneShield : MonoBehaviour
{
    public DurationSkills skilldata;
    private HeroStats heroStats;
    public GameObject cyclone;
    private int BaseDamage;
    private DamageOverTimeTimer damageOverTime;
    private HitBoxDetection detection;
    public bool isSkillactive;
    private int consumption;
    void Start()
    {

        BaseDamage = skilldata.Damage;
        consumption = skilldata.EnergyConsumption;
        damageOverTime = GetComponentInChildren<DamageOverTimeTimer>();
    }
    public void ActivateSkill()
    {
        if(!isSkillactive)
        {
            damageOverTime.SetHeroStats(heroStats);
            isSkillactive= true;
            cyclone.SetActive(true);
            

        }
        
    }
    public int AttackDamage()
    {
        int attack = (BaseDamage * ( 2 + (heroStats.GetAttackDamage() / 100)));
        return attack;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSkillactive && heroStats.GetEnergy() > 0)
        {
            heroStats.Abilityisused((Time.deltaTime * consumption));
        }
        else
        {
            cyclone.SetActive(false);
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
