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
        player.IsHiding = true;
    }

    public override void ExitState()
    {
        
    }
    public override void FrameUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (player.delayTimeToToggleHide > 0)
                return;
            player.IsHiding = false;
            player.SetUnHide(Player.HidingType.None);
            player.stateMachine.ChangeState(player.IdleState);
            player.delayTimeToToggleHide = 2f;
        }
        if (player.delayTimeToToggleHide > 0)
        {
            player.delayTimeToToggleHide -= Time.deltaTime;
        }
        else
        {
            player.delayTimeToToggleHide = 0;
        }
    }

    public override void PhysicsUpdate()
    {
        
    }
}
