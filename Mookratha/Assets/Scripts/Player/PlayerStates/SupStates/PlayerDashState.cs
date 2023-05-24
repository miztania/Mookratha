using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAblilityState
{
    public bool CanDash { get; private set; }

    private bool isHolding;

    public float lastDashTime;

    private Vector2 dashDirection;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        CanDash = false;

        player.SetIsDash(true);

        player.InputHandler.UseDashInput();

        startTime = Time.time;

        isHolding = true;

       

    }

    public override void Exit()
    {
        player.SetIsDash(false);
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time <= startTime + playerData.dashTime) 
        {
          //  Debug.Log("Dassssssssssssssssssh");
        }
        else
        {
            lastDashTime= Time.time;
            isAbilityDone = true;
            isHolding= false;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public bool CheckIfCanDash()
    {
        return CanDash && Time.time >= lastDashTime + playerData.dashCoolDown;
    }


    public void ResetCanDash() => CanDash = true;

    

}
