using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    #region components
    private GameInput input;
    private Rigidbody2D RB2D;
    public CharacterData characterData;
    #endregion

    #region variables
    private int currentSpeed;
    #endregion
    private void Start()
    {
        input = GetComponent<GameInput>();
        RB2D = GetComponent<Rigidbody2D>();
        currentSpeed = characterData.initalMovementspeed;
    }

    // Update is called once per frame
    
    private void FixedUpdate()
    {
        Walk();
    }
    public void Walk()
    {
        RB2D.velocity = new Vector2(input.GetMovementInput().x * currentSpeed, input.GetMovementInput().y * currentSpeed);
    }
}
