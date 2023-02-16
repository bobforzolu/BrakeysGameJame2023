using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSystem 
{

    public event EventHandler OnLevelChanged;
    public event EventHandler OnExperinceEarned;
    private int level;
    private int experience;
    private float experienceToNextLevel;
    private float initalexp;
    private float modifier;

    public  LevelSystem()
    {
        level = 1;
        experience = 0;
        experienceToNextLevel = 100 ;
        modifier = .5f;
        
    }
    public void Addexperince(int Amount)
    {
        experience += Amount;
        if(experience >= experienceToNextLevel)
        {
            level++;
            experience = 0;
            OnLevelChanged?.Invoke(this, EventArgs.Empty);
        }
        OnExperinceEarned?.Invoke(this, EventArgs.Empty);
    }
    public void ExperinceModifier()
    {
        experienceToNextLevel += (experienceToNextLevel * .3f);
    }
    public int GetLevelNumber()
    {
        return level;
    }
    public int GetExperience()
    {


        return experience;
    }
    public float GetExperineceToNextLevel()
    {
        return experienceToNextLevel;
    }
}
