using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats 
{
    private int attack;
    private float attackSpeed;
    private int health;
    private int stamina, mana;
    private int movement;

    public HeroStats(CharacterData characterData)
    {
        attack = characterData.initalAttack;
        attackSpeed = characterData.initalttakSpeed;
        health = characterData.initalHealth;
        stamina = characterData.initaltamina;
        mana = characterData.initalMana;
        movement = characterData.initalSpeed;
    }
    public float GetAttackDamage(int OtherAttacksDamage)
    {
        float damage = attack * (1 + (OtherAttacksDamage/10));
        return damage;
    }
    public int GetAttackDamage()
    {
        int damage = attack ;
        return damage;
    }
    public int GetStamina()
    {
        return stamina;
    }
    public int GetMana()
    {
        return mana;
    }
    public float GetAttackSpeed()
    {
        return attackSpeed;
    }
    public int GetMovement()
    {
        return movement;
    }
    public void IncreasAllStats(int statIncrease)
    {
        attack += statIncrease;
        attackSpeed += statIncrease;
        health += statIncrease;
        movement += statIncrease;
        stamina += statIncrease;
        mana += statIncrease;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
   
}
