using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle_Hiding", menuName = "Player_Logic/Idle_Logic/Hiding")]
public class PlayerIdleHiding : PlayerIdleSOBase
{
    [SerializeField] private HideableObject hidingTarget;
    [SerializeField] private float delayTimeToToggleHide;
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
        base.DoFrameUpdateLogic();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (delayTimeToToggleHide > 0)
                return;
            if (hidingTarget != null)
            {
                hidingTarget.Interact();
                player.stateMachine.ChangeState(player.HidingState);
                delayTimeToToggleHide = 2f;
            }
        }
        if (delayTimeToToggleHide > 0)
        {
            delayTimeToToggleHide -= Time.deltaTime;
        }
        else
        {
            delayTimeToToggleHide = 0;
        }
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
