using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy", menuName =" Enemy/ Creat Enemy")]
public class EnemyData : ScriptableObject
{
    public Sprite EnemySprite;
    public float speed;
    public float health;
}
