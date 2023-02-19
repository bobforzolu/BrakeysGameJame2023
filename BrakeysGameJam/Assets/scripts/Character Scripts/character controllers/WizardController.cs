using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : HeroControler,IDamagable
{
    [SerializeField] private GameObject autoattackpoint;
    private wizardAutoAttack autoAttacks;
    private SkillCycloneShield cycloneShield;
    private SkillMeteorImpact meteorImpact;
    protected override void Awake()
    {
        base.Awake();
        autoAttacks = GetComponentInChildren<wizardAutoAttack>();
        autoAttacks.SetStatData(heroStats);
        cycloneShield= GetComponentInChildren<SkillCycloneShield>();
        cycloneShield.SetHeroData(heroStats);
        meteorImpact= GetComponentInChildren<SkillMeteorImpact>();
        meteorImpact.setHero(heroStats);
    }
    private void OnDisable()
    {
        input.playerInputActions.player.Skill1.performed -= Skill1_performed;
        input.playerInputActions.player.Skill2.started -= Skill2_started;
        input.playerInputActions.player.Skill2.canceled -= Skill2_canceled;

    }
    protected override void Start()
    {
        base.Start();

        input.playerInputActions.player.Skill1.performed += Skill1_performed;
        input.playerInputActions.player.Skill2.started += Skill2_started;
        input.playerInputActions.player.Skill2.canceled += Skill2_canceled;


    }

   

    private void Skill2_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        meteorImpact.Getmeteor();
    }

    private void Skill2_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        meteorImpact.GetMouseLocationPosition();
    }

    private void Skill1_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        cycloneShield.ActivateSkill();

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        AttackDirection(autoattackpoint);
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
