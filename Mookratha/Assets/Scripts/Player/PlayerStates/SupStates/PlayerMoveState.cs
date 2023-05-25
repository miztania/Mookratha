using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        if((input.x == 0 && input.y == 0) && !isHolding)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if (catchInput && !isHolding)
        {
            stateMachine.ChangeState(player.HoldingState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        float targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0f,targetAngle, 0f);

        player.RB.velocity = new Vector3(input.x * playerData.movementSpeed, 0.0f, input.y * playerData.movementSpeed);

      //  Vector3 direction = new Vector3(input.x,0.0f,input.y);  

      //  controller.Move(direction  * Time.deltaTime);
    }
}
