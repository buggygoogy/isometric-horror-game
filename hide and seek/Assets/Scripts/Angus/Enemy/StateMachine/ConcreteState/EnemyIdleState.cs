using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {

    }
    public override void AnimationTriggerEvent(Enemy.AnimationTriggerTypes triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
        enemy.EnemyIdleBaseInstance.DoAnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        enemy.EnemyIdleBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        enemy.EnemyIdleBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        enemy.EnemyIdleBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        enemy.EnemyIdleBaseInstance.DoPhysicsUpdateLogic();
    }
}
