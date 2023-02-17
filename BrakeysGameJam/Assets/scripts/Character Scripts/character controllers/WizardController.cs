using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : HeroControler
{
    private HeroStats heroStats;
    [SerializeField] private GameObject autoattackpoint;
    private KnightAutoAttack autoAttacks;
    private void Awake()
    {
        heroStats = new(characterData);
        autoAttacks = GetComponentInChildren<KnightAutoAttack>();
    }
    private void Start()
    {
        LoadData();
        autoAttacks.SetStatData(heroStats);


    }
    // Update is called once per frame
    private void Update()
    {
        AttackDirection(autoattackpoint);
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
