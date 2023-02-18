using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : HeroControler,IDamagable
{
    private ArcherAutoAttacks rangedAuto;
    public GameObject autoattackGameObject;
    private SkillAracherArrowRain arrowRain;
    private SkillArrowBomb arrowBomb;
    
    protected override void Awake()
    {
        base.Awake();
        rangedAuto = GetComponentInChildren<ArcherAutoAttacks>();
        arrowRain = GetComponentInChildren<SkillAracherArrowRain>();
        arrowBomb= GetComponentInChildren<SkillArrowBomb>();

        arrowBomb.SetHerodata(heroStats);
        arrowRain.SetHeroData(heroStats);
        rangedAuto.SetStatData(heroStats);
        rangedAuto.SetBombability(arrowBomb);
    }
    protected override void Start()
    {
        base.Start();
        input.playerInputActions.player.Skill1.started += Skill1_started;
        input.playerInputActions.player.Skill1.canceled += Skill1_canceled;
    }

    private void Skill1_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        arrowRain.ActivateAbility();
    }

    private void Skill1_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        arrowRain.AimAbility();
    }
    
    protected override void Update()
    {
        base.Update();
        AttackDirection(autoattackGameObject);
    }
    private void FixedUpdate()
    {
        Movement(heroStats.GetMovementSpeed());
    }

    public void Recover(int Amount)
    {
        throw new System.NotImplementedException();
    }
}
