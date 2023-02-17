using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : HeroControler
{
    private HeroStats heroStats;
    private ArcherAutoAttacks rangedAuto;
    public GameObject autoattackGameObject;
    private void Awake()
    {
        heroStats = new HeroStats(characterData);
        rangedAuto = GetComponentInChildren<ArcherAutoAttacks>();
        rangedAuto.SetStatData(heroStats);
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
        Movement(heroStats.GetMovementSpeed());
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
