using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput {get; private set;}
    
    //Horizontal input
    public int NormInputX { get; private set;}
    public int NormInputY { get; private set;}

    //Jump Input
    public bool JumpInput { get; private set;}
    public bool JumpInputStop { get; private set;}

    [SerializeField]
    private float inputHoldTime = 0.2f;

    private float jumpInputStartTime;


    //Dash Input 
    public bool DashInput { get; private set;}
    public bool DashInputStop { get; private set; }
    private float DashInputStartTime;

    //Attack Input 
    public bool[] AttackInputs { get; private set; }


    private void Start()
    {
        int countAmountOfAttack = Enum.GetValues(typeof(CombatInputs)).Length;
        AttackInputs = new bool[countAmountOfAttack];
    }

    private void Update()
    {

        //Debug.Log("Move Input : " + NormInputX + " : " + NormInputY);
        CheckJumpInputHoldTime();
        CheckDashInputHoldTime();
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.primary] = true;
        }
        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.primary] = false;
        }
    }

    public void OnScondAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.secondary] = true;
        }
        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    }


    public void OnMoveInput(InputAction.CallbackContext context)
    {

      
        RawMovementInput = context.ReadValue<Vector2>();


        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;

        Debug.Log("InputHandler"+" x:" + NormInputX + " y:" + NormInputY);


    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true ;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }


        /*
        if (context.started)
        {
            Debug.Log("Jump button pushed down");
        }

        if (context.performed)
        {
            Debug.Log("Jump button is being held down");
        }

        if (context.canceled)
        {
            Debug.Log("Jump button has been released");
        }
        */
    }

    public void UseJumoInput() => JumpInput = false ;  
 
    private void CheckJumpInputHoldTime()
    {
        if(Time.time >= jumpInputStartTime + inputHoldTime) 
        { 
            JumpInput = false ;
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DashInput= true ;
            DashInputStop = false ;
            DashInputStartTime= Time.time;
        }
        else if (context.canceled)
        {
            DashInputStop = true;
        }
    }

    public void UseDashInput() => DashInput= false ;

    private void CheckDashInputHoldTime()
    {
        if(Time.time >= DashInputStartTime + inputHoldTime)
        {
            DashInput = false ;
        }
    }


}

public enum CombatInputs
{
    primary,
    secondary,
}
