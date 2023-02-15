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
    public void FacingDirection()
    {
        float angle = Mathf.Atan2(input.GetMousePosition().y, input.GetMousePosition().x) * Mathf.Rad2Deg;
        angle -= 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 20* Time.deltaTime);
        Debug.Log(angle);
    }
 
   
    public virtual void AbilityOne()
    {

    }
    public virtual void AbilityTwo()
    {

    }

}
