using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats 
{
    private int attack;
    private float attackSpeed;
    private int health;
    private int maxHealth;
    private float energy;
    private float movement;
    private int maxEnergy;
    
    public CharacterData characterdata { get; private set; }

    public HeroStats(CharacterData characterData)
    {
        characterdata =  characterData;
        attack = characterData.initalAttack;
        attackSpeed = characterData.initalttakSpeed;
        maxHealth = characterData.initalHealth;
        health = characterData.initalHealth;
        maxEnergy = characterData.AbilityEnergy;
        energy = characterData.AbilityEnergy;
        movement = characterData.initalSpeed;
    }
  
    public int GetAttackDamage()
    {
        
        return attack;
    }
    public int getMaxHealth()
    {
        return maxHealth;
    }
    public int getMaxEnergy()
    {
        return maxEnergy;
    }
    public float GetEnergy()
    {
        return energy;
    }
   
    public float GetAttackSpeed()
    {
        return attackSpeed;
    }
    public float GetMovementSpeed()
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
        maxHealth += statIncrease;
        maxEnergy += statIncrease;
        health += statIncrease;
        movement += (statIncrease * 0.5f);
        energy += statIncrease;
    }
    public void levelStatincrease()
    {
        attack += 1;
        energy += 1;
        maxEnergy+= 1;
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
        maxHealth += increase;
        health+= increase;
    }
    public void IncreaseMovement(int increase)
    {
        movement += (increase *0.5f);
    }
    public void IncreaseAbilityEnergy(int increase)
    {
        energy += increase;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public void Abilityisused(float amount)
    {

        energy -= amount;
    }
    public void RecoverHealth()
    {
        if(health < maxHealth) { 
        health += (int)(Time.deltaTime * 1.1f) + (health / 100);
        }
    }
    public void RecoverEnergy()
    {
        if(energy < maxEnergy)
        {

        energy += (Time.deltaTime * 1.1f) + (maxEnergy/100);
        }
    }

    public string ToStringStats()
    {
        return $"hp: {maxHealth} \n attack: {attack} \n Energy: {maxEnergy}\n attackspeed: {attackSpeed}\n movement: {movement}";
    }
   
}
