using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAutoAttacks : MonoBehaviour
{
    private bool canattack;
    private HeroStats heroStats;
    public AutoAttackData attackData;
    public GameObject Projectile;
    private float timer;
   
    private int currentDamage;
    // Start is called before the first frame update
    void Start()
    {
        currentDamage = attackData.Damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SummonRangedProjectile()
    {
        if (canattack)
        {
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
        timer = timer = (attackData.AttackInterval - heroStats.GetAttackSpeed());

        return timer;
    }


    public void SetStatData(HeroStats heroStats)
    {
        this.heroStats = heroStats;
    }
}
