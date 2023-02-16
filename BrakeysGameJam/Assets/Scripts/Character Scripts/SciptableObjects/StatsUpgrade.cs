using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Stats Upgrade", menuName = "Character/ CharacterStat Upgrade")]
public class StatsUpgrade : ScriptableObject
{
    public int Amount;
    public string description;
    public StateUpgrade stateUpgrade;
    
    
    public void Upgrade( HeroStats heroStats)
    {
        if(stateUpgrade == StateUpgrade.attack) 
        {
            heroStats.IncreaseAttack(Amount);
        }
        else if(stateUpgrade == StateUpgrade.health)
        {
            heroStats.IncreaseHealthk(Amount);
        }
        else if(stateUpgrade == StateUpgrade.attackSpeed)
        {
            heroStats.IncreaseAttackSpeed(Amount);
        }
        else if(stateUpgrade == StateUpgrade.movement)
        {
            heroStats.IncreaseMovement(Amount);
        }
        else if(stateUpgrade == StateUpgrade.abilityEnergy) 
        { 
            heroStats.IncreaseAbilityEnergy(Amount);
        }
        else if(stateUpgrade == StateUpgrade.all)
        {
            heroStats.IncreasAllStats(Amount);
        }
    }
public enum StateUpgrade
{
    attack,
    health,
    attackSpeed,
    movement,
    abilityEnergy,
    all

};
    
    
}
