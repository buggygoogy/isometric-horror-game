using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }

    public override void AnimationTriggerEvent(Player.AnimationTriggerTypes triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(GetInputVelocity())
        {
            player.stateMachine.ChangeState(player.WalkState);
        }
        else
        {
            player.PlayerMove(player.moveVelocity);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            player.ItemInteract();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (player.delayTimeToToggleHide > 0)
                return;
            if (player.hidingTarget != null)
            {
                player.hidingTarget.Interact();
                player.stateMachine.ChangeState(player.HidingState);
                player.delayTimeToToggleHide = 2f;
            }
        }
        if (player.delayTimeToToggleHide < 0)
        {
            player.delayTimeToToggleHide = 0;
            return;
        }
        else
        {
            player.delayTimeToToggleHide -= Time.deltaTime;
        }



    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public bool GetInputVelocity()
    {
        return player.moveVelocity != Vector3.zero;
    }

}
