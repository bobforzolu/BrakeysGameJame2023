using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Camera cam;
    private void Awake()
    {
         playerInputActions = new PlayerInputActions();
        playerInputActions.player.Enable();
    }
    void Start()
    {
        cam = Camera.main;
        
    }
    public Vector2 GetMovementInput()
    {
        Vector2 inputValue = playerInputActions.player.movement.ReadValue<Vector2>();

        inputValue = inputValue.normalized;

        return inputValue;
    }
    public Vector2 GetMousePosition()
    {
        Vector3 rawmouseposition = playerInputActions.player.Aim.ReadValue<Vector2>();
        Vector3 mouseposition =cam.ScreenToWorldPoint(rawmouseposition);
        Vector3 direction = mouseposition - transform.position;

        return direction;
    }

   
}
