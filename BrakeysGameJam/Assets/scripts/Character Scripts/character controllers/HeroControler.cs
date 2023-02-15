using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeroControler :MonoBehaviour
{
    private GameInput input;
    private Rigidbody2D RB2D;
    public  CharacterData characterData;
    protected KnightAutoAttack autoattack;

    public virtual void LoadData()
    {
        input = GetComponent<GameInput>();
        RB2D = GetComponent<Rigidbody2D>();
        autoattack = GetComponentInChildren<KnightAutoAttack>();
    }
    
   
    public  void Movement(int speed)
    {
        RB2D.velocity = new Vector2(input.GetMovementInput().x * speed, input.GetMovementInput().y *speed);

    }
    public virtual void AbilityOne()
    {

    }
    public virtual void AbilityTwo()
    {

    }

}
