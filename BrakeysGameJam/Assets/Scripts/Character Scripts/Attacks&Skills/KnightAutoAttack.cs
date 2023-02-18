using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAutoAttack : MonoBehaviour
{
    private bool canattack;
    private HeroStats heroStats;
    public AutoAttackData attackData;
    private float timer;
    public Collider2D hitbox;
    private HitBoxDetection hitDetectBox;


    private int currentDamage;

    void Start()
    {
        hitDetectBox = GetComponentInChildren<HitBoxDetection>();
        canattack = false;
        currentDamage = attackData.Damage;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    public void Attack()
    {
        if (canattack)
        {
            hitDetectBox.SetableDoDamage(heroStats.GetAttackDamage());
            timer = TimeUntilAttack();
            canattack = false;
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                canattack = true;
            }
        }

    }
    private float TimeUntilAttack()
    {
        timer = timer = (attackData.DeacresAutoattackCooldown - heroStats.GetAttackSpeed());

        return timer;
    }


    public void SetStatData(HeroStats heroStats)
    {
        this.heroStats = heroStats;
    }
    
}
