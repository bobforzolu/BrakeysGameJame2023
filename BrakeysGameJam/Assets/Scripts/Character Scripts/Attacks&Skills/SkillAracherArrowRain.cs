using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAracherArrowRain : MonoBehaviour

{
    private GameInput playerControls;

    public Vector2 positiono;
    public GameObject AbilityPrefab;
    private HeroStats heroStats;
    public DurationSkills arrowrainData;
    private int baseAttack = 5;
    private int energycost;

    private void Start()
    {
        baseAttack = arrowrainData.Damage;
        energycost = arrowrainData.EnergyConsumption;
        playerControls =  GetComponentInParent<GameInput>();
    }
    public void AimAbility()
    {
        positiono = new Vector2(playerControls.RawMousePosition().x, playerControls.RawMousePosition().y) ;


    }
    public int AttackDamage()
    {
        int attack = baseAttack * (2 + (heroStats.GetAttackDamage() / 100));
        return attack;
    }
    public void ActivateAbility()
    {
        if(heroStats.GetEnergy() > arrowrainData.EnergyConsumption)
        {
            heroStats.Abilityisused(energycost);
            GameObject arrowrain =  ObjectPulling.instance.SpawnFromPool("Arrow rain", positiono,Quaternion.identity);
            arrowrain.GetComponent<DamageOverTimeTimer>().GetComponent<DamageOverTimeTimer>().SetHeroStats(heroStats);
            arrowrain.GetComponentInChildren<HitBoxDetection>().UpdateDamage(AttackDamage());

        }
    }
    public void SetHeroData(HeroStats heroStats)
    {
        this.heroStats = heroStats;

    }

}
