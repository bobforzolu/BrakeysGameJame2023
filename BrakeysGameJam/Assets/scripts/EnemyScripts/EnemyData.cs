using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy", menuName =" Enemy/ Creat Enemy")]
public class EnemyData : ScriptableObject
{
    public Sprite EnemySprite;
    public Color Color;
    public float speed;
    public int health;
    public int Damage;
    public int experience;


    public void RandomColor()
    {

    }
}