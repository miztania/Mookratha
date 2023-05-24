using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAblilityState : PlayerState
{
    protected bool isAbilityDone;
    protected PlayerInputHandler inputHandler;
    protected float xInput;
    protected float yInput;
    public PlayerAblilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        isAbilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


       // Debug.Log("isAbility :" + isAbilityDone);

        if (isAbilityDone) 
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
