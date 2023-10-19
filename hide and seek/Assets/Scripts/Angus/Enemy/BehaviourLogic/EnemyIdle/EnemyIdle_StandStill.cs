using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle-StandStill", menuName = "EnemyLogic/Idle Logic/StandStill")]
public class EnemyIdle_StandStill : EnemyIdleSoBase
{
    public float StandStillTime;
    public float MaxStandStillTime;
    public override void DoAnimationTriggerEvent(Enemy.AnimationTriggerTypes triggerTypes)
    {
        
    }

    public override void DoEnterLogic()
    {
        StandStillTime = MaxStandStillTime;
    }

    public override void DoExitLogic()
    {
        
    }

    public override void DoFrameUpdateLogic()
    {
        StandStillTime -= Time.deltaTime;
        enemy.MoveEnemy(transform.position);
        if (StandStillTime <= 0)
        {
            enemy.stateMachine.ChangeState(enemy.PatrolState);
        }
    }

    public override void DoPhysicsUpdateLogic()
    {
        
    }

    public override void Intialize(GameObject gameObject, Enemy enemy)
    {
        base.Intialize(gameObject, enemy);
    }

    public override void ResetValue()
    {
        base.ResetValue();
    }
}
