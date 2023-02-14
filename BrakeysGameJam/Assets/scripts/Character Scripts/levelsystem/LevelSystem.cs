using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSystem 
{

    public EventHandler OnLevelChanged;
    public EventHandler OnExperinceEarned;
    private int level;
    private int experience;
    private int experienceToNextLevel;

    public  LevelSystem()
    {
        level = 1;
        experience = 0;
        experienceToNextLevel = 100 ;

    }
    public void Addexperince(int Amount)
    {
        experience = Amount;
        if(experience >= experienceToNextLevel)
        {
            level++;
            experience -= experienceToNextLevel;
            OnLevelChanged?.Invoke(this, EventArgs.Empty);
        }
        OnExperinceEarned?.Invoke(this, EventArgs.Empty);
    }
    public int GetLevelNumber()
    {
        return level;
    }
}
