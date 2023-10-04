using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHidingState : PlayerState
{
    public PlayerHidingState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }

    public override void AnimationTriggerEvent(Player.AnimationTriggerTypes triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        player.IsHiding = true;
    }

    public override void ExitState()
    {
        base.ExitState();
    }
    public override void FrameUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player.delayTimeToToggleHide > 0)
                return;
            player.SetUnHide(IHideable.HidingType.None);
            player.stateMachine.ChangeState(player.IdleState);
            player.IsHiding = false;
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
        
    }
}
