using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Stats Upgrade", menuName = "Character/ CharacterStat Upgrade")]
public class StatsUpgrade : ScriptableObject
{
    public int StatsIncreaseAmount;
    public string description;
    public StateUpgrade stateUpgrade;
    
    
    public void Upgrade( HeroStats heroStats)
    {
        if(stateUpgrade == StateUpgrade.attack) 
        {
            heroStats.IncreaseAttack(StatsIncreaseAmount);
        }
        else if(stateUpgrade == StateUpgrade.health)
        {
            heroStats.IncreaseHealthk(StatsIncreaseAmount);
        }
        else if(stateUpgrade == StateUpgrade.attackSpeed)
        {
            heroStats.IncreaseAttackSpeed(StatsIncreaseAmount);
        }
        else if(stateUpgrade == StateUpgrade.movement)
        {
            heroStats.IncreaseMovement(StatsIncreaseAmount);
        }
        else if(stateUpgrade == StateUpgrade.abilityEnergy) 
        { 
            heroStats.IncreaseAbilityEnergy(StatsIncreaseAmount);
        }
        else if(stateUpgrade == StateUpgrade.all)
        {
            heroStats.IncreasAllStats(StatsIncreaseAmount);
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
