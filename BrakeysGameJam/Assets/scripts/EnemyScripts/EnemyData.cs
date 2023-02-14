using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy", menuName =" Enemy/ Creat Enemy")]
public class EnemyData : ScriptableObject
{
    public Sprite EnemySprite;
    public AnimatorController animationClip;
    public float speed;
    public float health;
    public Color Color;
}