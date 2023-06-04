using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerHoldStillState : PlayerState
{

    protected Vector2 input;
    protected CharacterController controller;
    protected bool dashInput;
    protected bool catchInput;
    protected bool isHolding;
    
    public PlayerHoldStillState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
      //  player.SetIsCanHold(false);
        player.SetIsHolding(true);
        player.RB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
      

        //    player.Throw();
    }

    public override void Exit()
    {
        base.Exit();
       
        // player.SetIsHolding(false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


        player.SetIsCanHold(false);

        input.x = player.InputHandler.NormInputX;
        input.y = player.InputHandler.NormInputY;
        dashInput = player.InputHandler.DashInput;
        catchInput = player.InputHandler.JumpInput;
        isHolding = player.isHolding;

        
        
        if (Time.time >= startTime + playerData.holdBeforeThrow + 0.5)
        {
            player.SetIsCanThrow(true);
        }
        

        


        if ((input.x != 0f || input.y != 0f) && isHolding)
        {
            stateMachine.ChangeState(player.HoldingState);
        }
        else if (catchInput && player.isCanThrow)
        {
            stateMachine.ChangeState(player.ThrowState);
        }



    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
