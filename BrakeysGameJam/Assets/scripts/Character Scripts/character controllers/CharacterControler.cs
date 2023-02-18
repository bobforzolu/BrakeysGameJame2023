using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    #region components
    private GameInput input;
    private Rigidbody2D RB2D;
    public CharacterData characterData;
    public GameObject autoattackHitbox;
    public bool attack;
    float attacktime;
    float currenttime;
    #endregion

    #region variables
    private int currentSpeed;
    #endregion
    private void Start()
    {
        input = GetComponent<GameInput>();
        RB2D = GetComponent<Rigidbody2D>();
        currentSpeed = characterData.initalSpeed;
        attacktime = 1f;
        currenttime = attacktime;
    }
    public void Update()
    {
        Attack();
    }
    // Update is called once per frame

    private void FixedUpdate()
    {
        Walk();
    }
    /// <summary>
    /// reads the control input and moves the character with physics
    /// </summary>
    public void Walk()
    {
        RB2D.velocity = new Vector2(input.GetMovementInput().x * currentSpeed, input.GetMovementInput().y * currentSpeed);
    }
    public void Attack()
    {
        autoattackHitbox.GetComponent<HitBoxDetection>().SetableDoDamage(4);
    }

}
