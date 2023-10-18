using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    [SerializeField] private float walkSpeed = 3;

    [SerializeField] private Vector3 moveVelocity;
    [SerializeField] private Vector2 facingDirection;
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            player.ItemInteract();
        }
        moveVelocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        facingDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        if (GetInputVelocity())
        {
            player.PlayerMove(moveVelocity, walkSpeed);
            player.PlayerRotate(facingDirection);
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
        base.PhysicsUpdate();
    }
    public bool GetInputVelocity()
    {
        return moveVelocity != Vector3.zero;
    }

}
