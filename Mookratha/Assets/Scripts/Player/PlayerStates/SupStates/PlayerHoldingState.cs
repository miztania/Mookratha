using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldingState : PlayerMoveState
{
    public PlayerHoldingState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();

        player.PickUp();
        player.SetIsHolding(true);
      
    }

    public override void Exit()
    {
        base.Exit();
      // player.SetIsHolding(false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


        if (Time.time <= startTime + playerData.holdBeforeThrow)
        {
          
        }
        else
        {

            player.SetIsCanThrow(true);

        }

        if (player.isGetingHit)
        {
            stateMachine.ChangeState(player.GetHitState);
        }
        else if ((input.x == 0 && input.y == 0) && isHolding)
        {
            stateMachine.ChangeState(player.HoldStillState);
        }
        else if(catchInput && player.isCanThrow)
        {
            stateMachine.ChangeState(player.ThrowState);
        }
    

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
