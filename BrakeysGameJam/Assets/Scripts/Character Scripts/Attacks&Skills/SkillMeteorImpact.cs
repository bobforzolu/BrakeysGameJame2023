using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class SkillMeteorImpact : MonoBehaviour
{
    public  DurationSkills skillData;
    private HeroStats heroStats;
    public GameObject attackpoint;
    private int BaseDamage;
    private GameInput playerControls;
    private int numArrows;



    public int AutoAttackLeve;
    private float angleBetweenArrows = 10.0f;
    private void Start()
    {
        numArrows = 1;
        
        playerControls = GetComponentInParent<GameInput>();
    }
    public void GetMouseLocationPosition()
    {

    }
    public void Getmeteor()
    {
        if(heroStats.GetEnergy() > skillData.EnergyConsumption) 
        {
            heroStats.Abilityisused(skillData.EnergyConsumption);
            // Calculate the total angle of the spread of arrows
            float totalAngle = angleBetweenArrows * (numArrows - 1);

            // Calculate the starting angle for the first arrow
            float startingAngle = transform.eulerAngles.z - totalAngle / 2;

            // Spawn each arrow
            for (int i = 0; i < numArrows; i++)
            {
                // Calculate the angle for this arrow
                float angle = startingAngle + i * angleBetweenArrows;

                // Instantiate a new arrow from the prefab
                GameObject newArrow = ObjectPulling.instance.SpawnFromPool("WizardMeteor", attackpoint.transform.position, Quaternion.identity);
                newArrow.GetComponent<DamageOverTimeTimer>().GetComponent<DamageOverTimeTimer>().SetHeroStats(heroStats);
                newArrow.GetComponentInChildren<HitBoxDetection>().UpdateDamage(AttackDamage());


                // Set the rotation of the new arrow to match the angle
                newArrow.transform.eulerAngles = new Vector3(0, 0, angle);

                // Set the direction of the arrow's movement to the player's forward vector
                Vector2 arrowDirection = Quaternion.Euler(0, 0, angle) * Vector2.up;

                // Set the velocity of the arrow's rigidbody to the arrow direction times the arrow speed
                Rigidbody2D arrowRigidbody = newArrow.GetComponent<Rigidbody2D>();
                arrowRigidbody.velocity = arrowDirection * 6;
            }
        }
    }




    public int AttackDamage()
    {
        int attack = (int)(BaseDamage * (1 + (heroStats.GetAttackDamage() / 100)));
        return attack;
    }

    public void setHero( HeroStats hero)
    {
        this.heroStats = hero;
    }
}
