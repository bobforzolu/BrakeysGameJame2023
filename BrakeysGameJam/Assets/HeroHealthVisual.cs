using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHealthVisual : MonoBehaviour
{
    public Slider health;
    public Slider EnergyBar;
    private HeroStats heroStats;
    private LevelSystem level;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health.maxValue = heroStats.getMaxHealth();
        health.value = heroStats.GetHealth();
        EnergyBar.maxValue = heroStats.getMaxEnergy();
        EnergyBar.value = heroStats.GetEnergy();


    }
    private void OnDestroy()
    {
    }

   

    public void SetlevelSystem(LevelSystem levelSystem)
    {
        level= levelSystem;
    }
    public void SetHeroStats(HeroStats heroStats)
    {
        this.heroStats = heroStats;
    }
    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
    }
}
