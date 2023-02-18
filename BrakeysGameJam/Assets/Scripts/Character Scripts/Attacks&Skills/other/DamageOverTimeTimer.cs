using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTimeTimer : MonoBehaviour
{
    private float duration;
    private float attackInterval;

    private float durationTimer;
    private float attackTimer;

    public DurationSkills skills;
    private HeroStats heroStats;
    private HitBoxDetection hitBoxDetection;
    private bool canAttack;
    private bool startattack;
    void Start()
    {
        hitBoxDetection = GetComponentInChildren<HitBoxDetection>();

       SetTimers();
    }
    public void SetTimers()
    {
        durationTimer = baseDuration();
        attackTimer = baseAttackInterval();
    }

    // Update is called once per frame
    void Update()
    {
        if(durationTimer> 0)
        {
            durationTimer -= Time.deltaTime;
            if(attackTimer < 0)
            {
                hitBoxDetection.DoDamage();
                Debug.Log("damage :"+hitBoxDetection.Damage());
               attackTimer =  baseAttackInterval();
            }
            else
            {
                attackTimer-= Time.deltaTime;
            }
        }
        else
        {
            transform.gameObject.SetActive(false);
            durationTimer = baseDuration();
        }


    }

    public float baseDuration()
    {
        float newDuration = skills.skillDuration;
      
        
        duration= newDuration;
        return duration;
    }

    public float baseAttackInterval()
    {
        float newInterval = skills.attackInterval;
        attackInterval=  newInterval;
        return attackInterval;
    }
   
    public void SetHeroStats(HeroStats heroStats)
    {
        this.heroStats = heroStats;
      

    }




}
