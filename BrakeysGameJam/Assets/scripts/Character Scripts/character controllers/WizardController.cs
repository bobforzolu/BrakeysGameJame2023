using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : HeroControler
{
    [SerializeField] private GameObject autoattackpoint;
    private wizardAutoAttack autoAttacks;
    private SkillCycloneShield cycloneShield;
    protected override void Awake()
    {
        base.Awake();
        autoAttacks = GetComponentInChildren<wizardAutoAttack>();
        autoAttacks.SetStatData(heroStats);
        cycloneShield= GetComponentInChildren<SkillCycloneShield>();
        cycloneShield.SetHeroData(heroStats);
    }
    protected override void Start()
    {
        base.Start();

        input.playerInputActions.player.Skill1.performed += Skill1_performed;


    }

    private void Skill1_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        cycloneShield.ActivateSkill();
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

  
}
