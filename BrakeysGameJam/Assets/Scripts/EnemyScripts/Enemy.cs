using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy 
{
    public int currentHealth;
    public int damage;

    public Enemy(EnemyData data)
    {
        currentHealth = data.health;
        damage = data.Damage;

    }

    public int DoDamage()
    {
        return damage;
    }

    public void HealthAfterDamage(int damage)
    {
        currentHealth -= damage;

        
        
    }
    public int Currenthealth()
    {
        return currentHealth;
    }

}
