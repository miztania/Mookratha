using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerGroundedState : PlayerState
{

    protected Vector2 input;
    protected CharacterController controller;
    protected bool dashInput;
    protected bool catchInput;
    protected bool isHolding;
    protected bool isMoving;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        input.x = player.InputHandler.NormInputX;
        input.y = player.InputHandler.NormInputY;
        dashInput = player.InputHandler.DashInput;
        catchInput = player.InputHandler.JumpInput;
        isHolding = player.isHolding;

        isMoving = (input.x != 0 || input.y != 0);

        if (dashInput && !isHolding)
        {
            stateMachine.ChangeState(player.DashState);
        }
        else if (player.isCanHold && catchInput && player.item.gameObject.tag  == "food")
        {
            stateMachine.ChangeState(player.HoldingState);
        }
        else if (isMoving && !isHolding)
        {
            stateMachine.ChangeState(player.MoveState);
        }
       
      
       




    }
    



    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }

    
}
