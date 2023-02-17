using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy 
{
    public float currentHealth;
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

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        
        
    }
    public float Currenthealth()
    {
        return currentHealth;
    }

}
