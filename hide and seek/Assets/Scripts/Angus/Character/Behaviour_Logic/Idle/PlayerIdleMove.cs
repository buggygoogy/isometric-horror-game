using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle_Move", menuName = "Player_Logic/Idle_Logic/Move")]
public class PlayerIdleMove : PlayerIdleSOBase
{
    [SerializeField]private float walkSpeed = 3;

    [SerializeField] private Vector3 moveVelocity;
    [SerializeField] private Vector2 facingDirection;
    public override void DoAnimationTriggerEvent(Player.AnimationTriggerTypes triggerTypes)
    {
        base.DoAnimationTriggerEvent(triggerTypes);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {

    }

    public override void DoPhysicsUpdateLogic()
    {
        base.DoPhysicsUpdateLogic();
    }

    public override void Intialize(GameObject gameObject, Player player)
    {
        base.Intialize(gameObject, player);
    }

    public override void ResetValue()
    {
        base.ResetValue();
    }
}
