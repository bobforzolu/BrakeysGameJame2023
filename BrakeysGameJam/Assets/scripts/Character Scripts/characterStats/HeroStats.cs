using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats 
{
    private int attack;
    private float attackSpeed;
    private int health;
    private int abiltyenergy;
    private int movement;
    public CharacterData characterdata { get; private set; }

    public HeroStats(CharacterData characterData)
    {
        characterdata =  characterData;
        attack = characterData.initalAttack;
        attackSpeed = characterData.initalttakSpeed;
        health = characterData.initalHealth;
        abiltyenergy = characterData.AbilityEnergy;
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
    public int GetAbilityEnergy()
    {
        return abiltyenergy;
    }
   
    public float GetAttackSpeed()
    {
        return attackSpeed;
    }
    public int GetMovementSpeed()
    {
        return movement;
    }
    public int GetHealth(){
        return health;
    }
  
    public void IncreasAllStats(int statIncrease)
    {
        attack += statIncrease;
        attackSpeed += (statIncrease * 0.03f);
        health += statIncrease;
        movement += statIncrease;
        abiltyenergy += statIncrease;
    }
    public void levelStatincrease()
    {
        attack += 1;
        abiltyenergy += 1;
        health += 2;


    }
    public void IncreaseAttack( int increase)
    {
        attack += increase ;
    }
    public void IncreaseAttackSpeed(int increase)
    {
        attackSpeed += (increase * 0.03f);
    }
    public void IncreaseHealthk(int increase)
    {
        health += increase;
    }
    public void IncreaseMovement(int increase)
    {
        movement += increase;
    }
    public void IncreaseAbilityEnergy(int increase)
    {
        abiltyenergy += increase;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void ToStringStats()
    {
        Debug.Log($"hp: {health} \n attack: {attack} \n Energy: {abiltyenergy}\n attackspeed: {attackSpeed}\n movement: {movement}");
    }
   
}
