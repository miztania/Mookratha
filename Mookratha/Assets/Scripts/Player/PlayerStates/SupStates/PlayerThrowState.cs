using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowState : PlayerAblilityState
{
    public PlayerThrowState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        player.SetFinishedThrowTime(Time.time);
        player.SetIsCanThrow(false);
 
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();



        player.SetIsCanHold(false);

        if (Time.time <= startTime + playerData.throwTime)
        {
            //  Debug.Log("Dassssssssssssssssssh");
        }
        else
        {
            player.Throw();
            isAbilityDone = true;
            stateMachine.ChangeState(player.IdleState);
       
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
