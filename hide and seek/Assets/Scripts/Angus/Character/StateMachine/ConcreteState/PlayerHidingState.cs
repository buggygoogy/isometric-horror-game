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
    }

    public override void ExitState()
    {
        base.ExitState();
    }
    public override void FrameUpdate()
    {
        if(Input.GetKey(KeyCode.E))
        {
            player.SetUnHide(IHideable.HidingType.None);
            player.stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        
    }
}
