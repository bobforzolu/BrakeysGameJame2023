using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
         playerInputActions = new PlayerInputActions();
        playerInputActions.player.Enable();
    }
    void Start()
    {
        
    }
    public Vector2 GetMovementInput()
    {
        Vector2 inputValue = playerInputActions.player.movement.ReadValue<Vector2>();

        inputValue = inputValue.normalized;

        return inputValue;
    }

   
}
