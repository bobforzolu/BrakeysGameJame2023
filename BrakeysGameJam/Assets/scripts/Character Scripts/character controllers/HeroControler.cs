using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeroControler :MonoBehaviour
{
    private GameInput input;
    private Rigidbody2D RB2D;
    public  CharacterData characterData;

    public virtual void LoadData()
    {
        input = GetComponent<GameInput>();
        RB2D = GetComponent<Rigidbody2D>();
    }
    
   
    public  void Movement(int speed)
    {
        RB2D.velocity = new Vector2(input.GetMovementInput().x * speed, input.GetMovementInput().y *speed);

    }
    public void AttackDirection(GameObject autoattack)
    {
        float angle = Mathf.Atan2(input.GetMousePosition().y, input.GetMousePosition().x) * Mathf.Rad2Deg;
        angle -= 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        autoattack.transform.rotation = Quaternion.Slerp(autoattack.transform.rotation, rotation, 20* Time.deltaTime);

        
    }
    public void GetAngle()
    {

    }
 
   
    public virtual void AbilityOne()
    {

    }
    public virtual void AbilityTwo()
    {

    }

}
