using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class SkillMeteorImpact : MonoBehaviour
{
    public  AttackAbilitys skillData;
    private HeroStats heroStats;
    public GameObject meteor;
    private int BaseDamage;
    private GameInput playerControls;
    private  Vector2 mouseposition;
    private Transform cameratop;

    private void Start()
    {
        
        playerControls = GetComponentInParent<GameInput>();
        cameratop = GameObject.FindGameObjectWithTag("Meteor").transform;
    }
    public void GetMouseLocationPosition()
    {
        mouseposition = new Vector2(playerControls.RawMousePosition().x, playerControls.RawMousePosition().y);

    }
    public void Getmeteor()
    {
        GameObject obj = ObjectPulling.instance.SpawnFromPool("WizardMeteor", cameratop.position, Quaternion.identity);
        Vector3 direction = obj.transform.position - transform.position;
        float distance = direction.magnitude;

        // Normalize the direction vector and multiply it by the speed
        Vector3 velocity = direction.normalized * 10;

        // Apply the velocity to the rigidbody
        obj.GetComponent<Rigidbody2D>().velocity = velocity;

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
