using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem 
{
    private int level;
    private int experience;
    private int experienceToNextLevel;

    public  LevelSystem()
    {
        level = 0;
        experience = 0;
        experienceToNextLevel = 100 ;

    }
    private void Addexperince(int Amount)
    {
        experience = Amount;
        if(experience >= experienceToNextLevel)
        {
            level++;
            experience -= experienceToNextLevel;
        }
    }
}
