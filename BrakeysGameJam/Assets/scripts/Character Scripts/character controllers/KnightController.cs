using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController :HeroControler
{
    private KnightAutoAttack autoAttack;
    public GameObject AttackPoint;

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();

        autoAttack = GetComponentInChildren<KnightAutoAttack>();

        autoAttack.SetStatData(heroStats);
        

    }
    
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        AttackDirection(AttackPoint);   
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

   public void Recover(int Amount)
    {
        throw new System.NotImplementedException();
    }
}
