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
    public bool isanimationDone;


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
                hitDetectBox.SetableDoDamage(heroStats.GetAttackDamage() + attackData.Damage);
                timer = TimeUntilAttack();
            Debug.Log("dd done");
                canattack = false;
        }
        else
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                canattack = true;
            }
        }

       
       

    }
    private float TimeUntilAttack()
    {
        timer = (attackData.AutoattackCoolDown );
        

        return timer;
    }


    public void SetStatData(HeroStats heroStats)
    {
        this.heroStats = heroStats;
    }
    
}
