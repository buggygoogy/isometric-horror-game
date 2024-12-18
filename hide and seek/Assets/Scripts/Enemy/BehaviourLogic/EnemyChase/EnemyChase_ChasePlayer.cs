using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chase-ChasePlayer", menuName = "EnemyLogic/Chase Logic/ChasePlayer")]
public class EnemyChase_ChasePlayer : EnemyChaseSoBase
{
    public GameObject player;
    public override void DoAnimationTriggerEvent(Enemy.AnimationTriggerTypes triggerTypes)
    {
        base.DoAnimationTriggerEvent(triggerTypes);
    }

    public override void DoEnterLogic()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void DoExitLogic()
    {
        
    }

    public override void DoFrameUpdateLogic()
    {
        enemy.MoveEnemy(player.transform.position);
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
