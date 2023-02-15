using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController :HeroControler
{
    private HeroStats heroStats;
    private void Awake()
    {
        heroStats = new(characterData);
    }
    private void Start()
    {
        LoadData();
        autoattack.SetStatData(heroStats);
        

    }
    // Update is called once per frame
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Movement(characterData.initalSpeed);
    }
    public override void AbilityOne()
    {
        base.AbilityOne();
    }
    public override void AbilityTwo()
    {
        base.AbilityTwo();
    }

    public override void LoadData()
    {
        base.LoadData();
        
    }
  
}
