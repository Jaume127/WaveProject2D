using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Añadir libreria que maneja el NewInputSystem

public class PlayerInputHandle : MonoBehaviour
{
    public Vector2 moveInput;
    public bool isAttacking;

    PlayerInput pInput;

    private void Awake()
    {
        pInput = GetComponent<PlayerInput>();
    }

    #region Input Methods

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started && !isAttacking)
        {
            isAttacking = true;
        }
    }


    #endregion






}
