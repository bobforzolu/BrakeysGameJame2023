using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : HeroControler
{
    private HeroStats heroStats;
    public GameObject autoattackGameObject;
    private void Awake()
    {
        heroStats = new HeroStats(characterData);
        LoadData();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        AttackDirection(autoattackGameObject);
    }
    private void FixedUpdate()
    {
        Movement(heroStats.GetMovement());
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
