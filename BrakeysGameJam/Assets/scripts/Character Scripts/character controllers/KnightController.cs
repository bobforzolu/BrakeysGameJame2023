using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController :HeroControler
{
    private HeroStats heroStats;
    private KnightAutoAttack autoAttack;
    public GameObject AttackPoint;

    private void Awake()
    {
        heroStats = new(characterData);
    }
    private void Start()
    {
        LoadData();

        autoAttack = GetComponentInChildren<KnightAutoAttack>();

        autoAttack.SetStatData(heroStats);
        

    }
    // Update is called once per frame
    private void Update()
    {
        AttackDirection(AttackPoint);   
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
