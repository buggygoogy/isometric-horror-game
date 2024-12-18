using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu(fileName = "Patrol-RandomWander", menuName = "EnemyLogic/Patrol Logic/ RandomWander")]
public class EnemyPatrol_RandomWander : EnemyPatrolSoBase
{
    public float patrolRange;

    private Vector3 _targetPos;

    public override void DoAnimationTriggerEvent(Enemy.AnimationTriggerTypes triggerTypes)
    {
        base.DoAnimationTriggerEvent(triggerTypes);
    }

    public override void DoEnterLogic()
    {
        _targetPos = GetRandomPoint();
    }

    public override void DoExitLogic()
    {

    }

    public override void DoFrameUpdateLogic()
    {
        if (enemy.isAggroed)
        {
            enemy.stateMachine.ChangeState(enemy.ChaseState);
        }
        else
        {
            enemy.MoveEnemy(_targetPos);
            Vector3 targetPoint = new Vector3(_targetPos.x, transform.position.y, _targetPos.z);
            if (Vector3.Distance(targetPoint, enemy.transform.position) <= enemy.Agent.stoppingDistance)
            {
                enemy.stateMachine.ChangeState(enemy.IdleState);
            }

            
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
    public Vector3 GetRandomPoint()
    {
        float randomX = Random.Range(-patrolRange, patrolRange);
        float randomZ = Random.Range(-patrolRange, patrolRange);
        Vector3 randomPoint = new Vector3(enemy.transform.position.x + randomX, enemy.transform.position.y, enemy.transform.position.z + randomZ);
        NavMeshHit hit;
        Vector3 target = NavMesh.SamplePosition(randomPoint, out hit, patrolRange, 1) ? hit.position : enemy.transform.position;
        Debug.Log(target);
        return target;
    }
}
